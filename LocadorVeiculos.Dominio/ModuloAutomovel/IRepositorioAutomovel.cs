﻿namespace LocadorAutomoveis.Dominio.ModuloAutomovel
{
    public interface IRepositorioAutomovel : IRepositorio<Automovel>
    {
        List<Automovel> SelecionarTodos(bool carregarGrupo = false);
        Automovel SelecionarPorMarcaModelo(string marca, string modelo);
    }
}
