using LocadorAutomoveis.Dominio.ModuloClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.WinApp.ModuloClientes
{
    public class ConfiguracaoToolBoxClientes : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Clientes";

        public override string TooltipInserir => "Inserir novo Clientes";

        public override string TooltipEditar => "Editar um Clientes existente";

        public override string TooltipExcluir => "Excluir um Clientes existente";
    }
}
