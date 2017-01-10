using InnAdministrator.Data.Entities;
using InnAdministrator.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace InnAdministrator.Controllers
{
    public class InnAdministratorController
    {
       private readonly IInnAdministrator _innAdministrator;
        
        public InnAdministratorController(IInnAdministrator innAdministrator)
        {
            _innAdministrator = innAdministrator;
        }

        public void UpdateQuality()
        {
            try
            {
                _innAdministrator.UpdateQuality();
            }
            catch (Exception ex)
            {
                //TODO: Use our logging interface to Log the exception:
            }

        }
    }
}
