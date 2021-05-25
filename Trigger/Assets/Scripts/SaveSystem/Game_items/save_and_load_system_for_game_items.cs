using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class save_and_load_system_for_game_items
{
    public static void save_system_for_game_items(save_and_load_manager_for_game_items _Game_Items)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game_item_data.psi";
        FileStream stream = new FileStream(path, FileMode.Create);

        data_for_game_items data = new data_for_game_items(_Game_Items);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static data_for_game_items load_system_for_game_items()
    {
        string path = Application.persistentDataPath + "/game_item_data.psi";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data_for_game_items data = formatter.Deserialize(stream) as data_for_game_items;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
