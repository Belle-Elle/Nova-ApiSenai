using NovaApi_SenaiHotspot.Context;
using NovaApi_SenaiHotspot.Domains;
using NovaApi_SenaiHotspot.Interface;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NovaApi_SenaiHotspot.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly HotspotContext ctx;

        public UsuarioRepository(HotspotContext appContext)
        {
            ctx = appContext;
        }

        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(idUsuario);


            usuarioBuscado.Senha = usuarioAtualizado.Senha;

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios
                 .Select(u => new Usuario()
                 {
                     Id = u.Id,
                     NIF = u.NIF,


                 })
                 .FirstOrDefault(u => u.Id == idUsuario);
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public Usuario Login(string NIF, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.NIF == NIF && u.Senha == senha);
        }
    }
}
