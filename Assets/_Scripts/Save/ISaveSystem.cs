﻿namespace TwoDoors.Save
{
    public interface ISaveSystem
    {
        void Save(SaveData data);

        SaveData Load();
    }
}