using UnityEngine;

public class DemoUI : MonoBehaviour {
    //[SerializeField] UserDataManagment m_usrDtaMngmnt;
    MultiplayerBootstrap mp;
    string code = "";

    private void Awake() => mp = FindAnyObjectByType<MultiplayerBootstrap>();

    private void OnGUI() {
        GUILayout.BeginArea(new Rect(20, 20, 280, 170), GUI.skin.box);
        GUILayout.Label("Multiplayer Demo");
        if (GUILayout.Button("Host (create lobby)")) mp.Host();
        if (GUILayout.Button("Quick Join")) mp.QuickJoin();
        //GUILayout.Label(m_usrDtaMngmnt.userData.userData);

        GUILayout.Space(6);
        GUILayout.Label("Join with code");
        code = GUILayout.TextField(code);
        if (GUILayout.Button("Join(code)")) mp.JoinWithCode(code);
        GUILayout.EndArea();

    }

}
