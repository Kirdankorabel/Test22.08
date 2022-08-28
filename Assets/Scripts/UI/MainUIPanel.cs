using UnityEngine;

public class MainUIPanel : MonoBehaviour
{
    private void Awake()
    {
        StaticInfo.date = DataSaver.loadData<Date>("save");
        if (StaticInfo.date == null)
            StaticInfo.date = new Date();
    }

    public void Close()
    {
        var date = new Date();
        date.VerticalPanelInfo = StaticInfo.VerticalPanel.UpdateState();
        date.AudioSettingsinfo = StaticInfo.AudioSettingsPanel.UpdateState();
        DataSaver.saveData<Date>(date, "save");
        Application.Quit();
    }
}