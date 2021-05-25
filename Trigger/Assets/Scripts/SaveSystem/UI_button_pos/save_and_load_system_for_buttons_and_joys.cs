using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class save_and_load_system_for_buttons_and_joys
{
    public static void save_system_for_buttons_and_joys(RectTransform j_t,RectTransform f_t,RectTransform jp_t,RectTransform r_t,RectTransform s_t)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/button_ui_pos_data.psi";
        FileStream stream = new FileStream(path, FileMode.Create);

        data_for_buttons_and_joys data = new data_for_buttons_and_joys(j_t, f_t, jp_t, r_t, s_t);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static data_for_buttons_and_joys load_system_for_buttons_and_joys()
    {
        string path = Application.persistentDataPath + "/button_ui_pos_data.psi";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data_for_buttons_and_joys data = formatter.Deserialize(stream) as data_for_buttons_and_joys;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
