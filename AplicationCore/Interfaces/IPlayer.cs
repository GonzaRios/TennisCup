using AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Interfaces
{
    public interface IPlayer
    {
        Players GetById(int id);
        List<Players> GetAll();
        Players Create(Players players);
        Players Update(int id, Players players);
    }
}
