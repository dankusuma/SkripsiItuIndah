using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.SignalR;
namespace SignalR.Services
{
    public class KapasitasHub : Hub
    {
        internal class notif
        {
           public int id_kelas;
           public bool val;
        }
        public Task UpdateKapasitas(int id_kelas,bool val)
        {
            notif n=new notif();
            n.id_kelas = id_kelas;
            n.val = val;
            return Clients.All.InvokeAsync("UpdateKelas", n);

        }
    }
}
