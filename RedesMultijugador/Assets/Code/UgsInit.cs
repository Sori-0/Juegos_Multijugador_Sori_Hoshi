using UnityEngine;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading;

public class UgsInit : MonoBehaviour
{
    private static readonly SemaphoreSlim Gate = new SemaphoreSlim(1, 1);
    private static Task initTask;
    private static bool loggedOnce;

    private async void Awake()
    {
        await InitAsync();
    }

    public static async Task InitAsync()
    {
        //Fast path: alredy ready 
        if(UnityServices.State == ServicesInitializationState.Initialized &&
            AuthenticationService.Instance.IsSignedIn)
        {
            LogOnce("[UGS] Alredy signed in : " + AuthenticationService.Instance.PlayerId);
            return;
        }

        //Someone else is already initializing? wait for it 
        if(initTask != null)
        {
            await initTask;
            LogOnce("[UGS] Signed in: " + AuthenticationService.Instance.PlayerId);
            return;
        }

        await Gate.WaitAsync();
        try
        {
            if (initTask == null)
                initTask = InitInnerAsync();
        }
        finally
        {
            Gate.Release();
        }

        await initTask;
        LogOnce("[UGS] Signed in " + AuthenticationService.Instance.PlayerId);
    }

    private static async Task InitInnerAsync()
    {
        if (UnityServices.State != ServicesInitializationState.Initialized)
            await UnityServices.InitializeAsync();
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }
            catch
            {
                // If another instance is racing us, swallow and left other one finish
                await Task.Yield();
            }
        }
    }

    private static void LogOnce(string msg) 
    {
        if (loggedOnce) return;
        loggedOnce = true;
        Debug.Log(msg);
    }
}
