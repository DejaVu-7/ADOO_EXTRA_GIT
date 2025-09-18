using System.IO;
using UnityEngine;

// clase para manejar el high score del juego usando un archivo json
public class HighScoreManager
{
    // ruta del archivo donde se guarda el high score
    private static string filePath => Application.persistentDataPath + "/highscore.json";

    [System.Serializable]
    private class HighScoreData
    {
        public int highScore; // valor del high score
    }

    // guarda el high score en el archivo
    public static void GuardarHighScore(int score)
    {
        HighScoreData data = new HighScoreData { highScore = score };
        File.WriteAllText(filePath, JsonUtility.ToJson(data)); // convierte a json y guarda
    }

    // carga el high score desde el archivo
    public static int CargarHighScore()
    {
        if (!File.Exists(filePath)) return 0; // si no existe el archivo, retorna 0
        string json = File.ReadAllText(filePath); // lee el archivo
        HighScoreData data = JsonUtility.FromJson<HighScoreData>(json); // convierte de json
        return data.highScore; // retorna el high score
    }
}
