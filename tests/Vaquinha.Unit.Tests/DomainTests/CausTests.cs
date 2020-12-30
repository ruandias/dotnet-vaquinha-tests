using FluentAssertions;
using Vaquinha.Tests.Common.Fixtures;
using Xunit;

namespace Vaquinha.Unit.Tests.DomainTests
{
    public class CausTests
    {
        [Collection(nameof(CausaFixtureCollection))]
    public class CausaTests: IClassFixture<CausaFixture>
    {
        private readonly CausaFixture _fixture;

        public CausaTests(CausaFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [Trait("Causa", "Causa_CorretamentePreenchida_CausaValida")]
        public void Causa_CorretamentePreenchida_CausaValida()
        {
            // Arrange
            var causa = _fixture.CausaValida();

            // Act
            var valido = causa.Valido();

            // Assert
            valido.Should().BeTrue(because: "os campos foram preenchidos corretamente");
            causa.ErrorMessages.Should().BeEmpty();
        }

        [Fact]
        [Trait("Causa", "Causa_NenhumDadoPreenchido_CausaInvalida")]
        public void Causa_NenhumDadoPreenchido_CausaInvalida()
        {
            // Arrange
            var causa = _fixture.CausaVazia();

            // Act
            var valido = causa.Valido();

            // Assert
            valido.Should().BeFalse(because: "deve possuir erros de preenchimento");
            causa.ErrorMessages.Should().HaveCount(3, because: "nenhum dos 3 campos obrigatórios foram informados ou estão incorretos.");

            causa.ErrorMessages.Should().Contain("O campo Nome é obrigatório.", because:"o campo Nome é obrigatório e não foi preenchido.");
            causa.ErrorMessages.Should().Contain("O campo Cidade é obrigatório.", because: "o campo Cidade é obrigatório e não foi preenchido.");
            causa.ErrorMessages.Should().Contain("O campo Estado é obrigatório.", because: "o campo Estado é obrigatório e não foi preenchido.");

        }

        [Fact]
        [Trait("Causa", "Causa_CausaCamposMaxLength_CausaInvalida")]
        public void Causa_CausaCamposMaxLength_CausaInvalida()
        {
            // Arrange
            var causa = _fixture.CausaMaxLength();

            // Act
            var valido = causa.Valido();

            // Assert
            valido.Should().BeFalse(because: "tamanho máximo de campos atingidos");
            causa.ErrorMessages.Should().HaveCount(3, because: "o preenchimento de 3 campos ultrapassaram o tamanho máximo permitido.");

            causa.ErrorMessages.Should().Contain("O campo Nome deve possuir no máximo 150 caracteres.", because: "o campo Nome ultrapassou o tamanho máximo permitido.");
            causa.ErrorMessages.Should().Contain("O campo Cidade deve possuir no máximo 150 caracteres.", because: "o campo Cidade ultrapassou o tamanho máximo permitido.");
            causa.ErrorMessages.Should().Contain("O campo Estado deve possuir no máximo 150 caracteres.", because: "o campo Estado ultrapassou tamanho máximo permitido.");
        }


    }
    }
}