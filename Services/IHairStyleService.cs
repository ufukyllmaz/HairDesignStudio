using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDesginStudio.Services
{
    public interface IHairStyleService
    {
        Task<List<string>> GenerateHairStyles(byte[] imageBytes, string userPrompt = "");
    }
}