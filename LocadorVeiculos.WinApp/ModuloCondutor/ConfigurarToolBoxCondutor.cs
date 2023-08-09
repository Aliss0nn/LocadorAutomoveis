using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.WinApp.ModuloCondutor
{
    public class ConfigurarToolBoxCondutor : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro De Condutores";

        public override string TooltipInserir => "Inserir novo Condutor";

        public override string TooltipEditar => "Editar um Condutor existente";

        public override string TooltipExcluir => "Excluir um Condutor existente";
    }
}
