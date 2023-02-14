using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    [SerializeField] private GameObject debugPanel;
    [SerializeField] TMPro.TMP_Text fpsField;
    [SerializeField] TMPro.TMP_Text plPosField;
    [SerializeField] TMPro.TMP_Text hpRealField;
    bool debugMenu;
    float timr_A;

    Transform plPos;
    string plHp;

    private void Start()
    {
        plPos = Overseer.GetPlayerControlls().transform;
        plHp = Overseer.GetPlayerHP().hp.ToString();
    }

    private void Update()
    {
        Check();
        FrameRateCounter();
        PositionAndHp();
    }

    private void Check()
    {
        if (Input.GetKeyDown(KeyCode.F3))
            debugMenu = !debugMenu;

        if (debugMenu)
            debugPanel.SetActive(true);
        else
            debugPanel.SetActive(false);
    }

    private void FrameRateCounter()
    {
        float current = 0;
        current = 1 / Time.deltaTime;

        
        if(timr_A <= 1)
            timr_A += Time.deltaTime;
        else
        {
            fpsField.text = "FPS :" + (Mathf.CeilToInt(current)).ToString();
            timr_A = 0;
        }
    }

    private void PositionAndHp()
    {
        plPosField.text = " /X/ " + ((int)plPos.position.x).ToString() + " /Y/ " + ((int)plPos.position.y).ToString() + " /Z/ " + ((int)plPos.position.z).ToString();
        hpRealField.text = plHp;
    }
}
