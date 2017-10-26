﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TheGameNinja.Data;

namespace TheGameNinja.Desktop.Services
{
    public interface IPlatformsRepository
    {
        Task<List<Platform>> GetAllPlatformsAsync();
    }
}
