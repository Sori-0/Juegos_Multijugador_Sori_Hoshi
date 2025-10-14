using UnityEngine;

public class BindBonesToXR : MonoBehaviour
{
    [SerializeField] Transform XRhead, XRleftHand, XRRightHand;
    [SerializeField] Transform titanHead, titanLeftHand, titanRightHand, titanHip;

    public void Intialize(Transform head, Transform leftHnad, Transform rightHand)
    {
        this.XRhead = head;
        this.XRleftHand = leftHnad;
        this.XRRightHand = rightHand;
    }

    private void Update()
    {
        titanHead.transform.position = XRhead.position;
        titanHip.transform.position = XRhead.position;
        titanLeftHand.transform.position = XRleftHand.position;
        titanRightHand.transform.position = XRRightHand.position;
    }
}
