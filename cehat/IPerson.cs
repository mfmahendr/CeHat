using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    // dibuat abstract karena awalnya belum tahu bagaimana pengimplementasianny
    // dan juga mungkin bisa jadi class nanti akan ada "akun premium" untuk
    // pengguna sehingga artinya class person ini nanti bisa diturunkan pada
    // class akun premium (Open-closed principle)
    public interface IPerson
    {
        int Id { get; set; }
        string Username { get; set; }
        string Password { get; set; }

        List<string> GetListUsername();
        string GetUsername(int id);
    }

}