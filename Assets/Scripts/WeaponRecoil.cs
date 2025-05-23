using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector] public Transform recoilFollowPos;
    [SerializeField] float kickBackAmount = -1;
    [SerializeField] float kickBackSpeed = 10, returnSpeed = 20;
    float currentRecoilPos, finalRecoilPos;
    

    // Update is called once per frame
    void Update()
    {
        currentRecoilPos = Mathf.Lerp(currentRecoilPos, 0, returnSpeed * Time.deltaTime);
        finalRecoilPos = Mathf.Lerp(finalRecoilPos, currentRecoilPos, kickBackSpeed * Time.deltaTime);
        recoilFollowPos.localPosition = new Vector3(0, 0, finalRecoilPos);
    }

    public void TriggerRecoil() => currentRecoilPos += kickBackAmount;
    
}
