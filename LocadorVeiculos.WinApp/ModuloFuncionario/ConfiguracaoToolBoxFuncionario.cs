using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.WinApp.ModuloFuncionario
{
    public class ConfiguracaoToolBoxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Fumcionario";

        public override string TooltipInserir => "Inserir novo Fumcionario";

        public override string TooltipEditar => "Editar um Fumcionario existente";

        public override string TooltipExcluir => "Excluir um Fumcionario existente";
    }
}
