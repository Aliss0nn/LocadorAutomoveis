using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.WinApp.ModuloTaxasEServicos
{
    public class ConfiguracaoToolBoxTaxaServico : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Taxas e Serviços";

        public override string TooltipInserir => "Inserir novo Taxas e Serviços";

        public override string TooltipEditar => "Editar Taxas e Serviços existentes";

        public override string TooltipExcluir => "Excluir Taxas e Serviços existentes";
    }
}
