using System;
using System.Linq;

public class ListeningSongs
{
    public int Listen(int[] durations1, int[] durations2, int minutes, int T)
    {
        Array.Sort(durations1);
        Array.Sort(durations2);

        var maxTime = minutes * 60;

        if (durations1.Length < T || durations2.Length < T)
        {
            return -1;
        }

        var time = durations1.Take(T).Sum() + durations2.Take(T).Sum();

        if (time > maxTime)
        {
            return -1;
        }

        var durations = durations1.Skip(T).Concat(durations2.Skip(T)).ToArray();
        Array.Sort(durations);

        var listenedSongs = 2 * T;

        foreach (var duration in durations)
        {
            time += duration;
            if (time > maxTime)
                break;
            listenedSongs++;
        }

        return listenedSongs;
    }
}
