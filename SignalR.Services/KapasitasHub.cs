using System;
using System.Web;
using Microsoft.AspNetCore.SignalR;
namespace SignalR.Services
{
    public class KapasitasHub:Hub
    {
        public void UpdateKapasitas(int ID_KELAS,Int16 KAPASITAS_BUKA)
        {
            Clients.All.InvokeAsync("UpdateKelas", ID_KELAS, KAPASITAS_BUKA);

        }
    }
}
