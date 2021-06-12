using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public interface IPerson
    {
        int Id { get; set; }
        string Username { get; set; }
        string Password { get; set; }

        List<string> GetListUsername();
        string GetUsername(int id);
    }

}