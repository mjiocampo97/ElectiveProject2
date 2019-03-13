using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.TransportationService
{
    public interface ITransportationService
    {

        List<Transportation> GetTransportationUser(UserAccount transporatationUnderUser);
        void AddTransportation(Transportation transportation);
        void DeleteTransportation(Transportation transportation);
        void UpdateTransportation(Transportation oldTransportation, Transportation newTransportation);
    }
}
