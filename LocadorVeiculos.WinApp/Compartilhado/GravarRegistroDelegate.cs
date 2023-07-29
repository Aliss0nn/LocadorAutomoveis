using LocadorAutomoveis.Dominio;

namespace LocadorAutomoveis.WinApp.Compartilhado
{

    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade disciplina)
        where TEntidade : EntidadeBase<TEntidade>;    
    
}
