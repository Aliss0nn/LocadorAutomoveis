using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.TestesIntegracao.ModuloFuncionário
{
    public class RepositorioFuncionarioEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_Funcionario()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Build();
            //action
            repositorioFuncionario.Inserir(funcionario);

            //assert
            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_editar_Funcionarios()
        {
            //arrange
            var funcionarioid = Builder<Funcionario>.CreateNew().Persist().Id;

            var funcionario = repositorioFuncionario.SelecionarPorId(funcionarioid);
            funcionario.Nome = "Alex";

            //action
            repositorioFuncionario.Editar(funcionario);

            //assert
            repositorioFuncionario.SelecionarPorId(funcionario.Id)
                .Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_excluir_Funcionario()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            //action
            repositorioFuncionario.Excluir(funcionario);

            //assert
            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_Funcionarios()
        {
            //arrange
            var domingos = Builder<Funcionario>.CreateNew().Persist();
            var renata = Builder<Funcionario>.CreateNew().Persist();

            //action
            var funcionario = repositorioFuncionario.SelecionarTodos();

            //assert
            funcionario.Should().ContainInOrder(domingos,renata);
            funcionario.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_por_nome()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            //action
            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorNome(funcionario.Nome);

            //assert
            funcionarioEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_selecionar_Funcionario_por_id()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            //action
            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            //assert            
            funcionarioEncontrado.Should().Be(funcionario);
        }



    }
}
