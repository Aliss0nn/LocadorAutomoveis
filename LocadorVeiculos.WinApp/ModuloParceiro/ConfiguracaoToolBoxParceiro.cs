using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.WinApp.ModuloParceiro
{
    internal class ConfiguracaoToolBoxParceiro : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Parceiros";

        public override string TooltipInserir => "Inserir Novo Parceiro";

        public override string TooltipEditar => "Editar um Parceiro existente";

        public override string TooltipExcluir => "Excluir um Parceiro existente";
    }
}
