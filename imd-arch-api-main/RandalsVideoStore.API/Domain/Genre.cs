using System;

namespace RandalsVideoStore.API
{
    // https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute?view=net-5.0
    [Flags]
    public enum Genre
    {
        Adventure = 0,
        SciFi = 1,
        Drama = 2,
        Romance = 4,
        Mystery = 8,
        Thriller = 16,

    }
}
