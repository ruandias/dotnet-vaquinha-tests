using System;
using Bogus;
using Vaquinha.Domain.Entities;
using Vaquinha.Domain.ViewModels;
using Xunit;

namespace Vaquinha.Tests.Common.Fixtures
{
    [CollectionDefinition(nameof(CausaFixtureCollection))]
    public class CausaFixtureCollection : ICollectionFixture<CausaFixture>
    {
    }
    public class CausaFixture
    {
        public CausaViewModel CausaModelValida()
        {
            var causa = new Faker();

            var faker = new Faker<CausaViewModel>("pt_BR");

            faker.RuleFor(c => c.Nome, (f, c) => causa.Lorem.Sentence(30));
            faker.RuleFor(c => c.Cidade, (f, c) => causa.Address.City());
            faker.RuleFor(c => c.Estado, (f, c) => causa.Address.StateAbbr());


            return faker.Generate();
        }

        public Causa CausaValida()
        {
            var causa = new Faker("pt_BR");

            var faker = new Faker<Causa>("pt_BR");

            faker.CustomInstantiator(f =>
                new Causa(Guid.NewGuid(), causa.Lorem.Sentence(30), causa.Address.City(), causa.Address.StateAbbr()));

            return faker.Generate();
        }

        public Causa CausaVazia()
        {
            return new Causa(Guid.Empty, string.Empty, string.Empty, string.Empty);
        }

        public Causa CausaMaxLength()
        {
            const string TEXTO_COM_MAIS_DE_150_CARACTERES = "AHIUDHASHOIFJOASJPFPOKAPFOKPKQPOFKOPQKWPOFEMMVIMWPOVPOQWPMVPMQOPIPQMJEOIPFMOIQOIFMCOKQMEWVMOPMQEOMVOPMWQOEMVOWMEOMVOIQMOIVMQEHISUAHDUIHASIUHDIHASIUHDUIHIAUSHIDUHAIUSDQWMFMPEQPOGFMPWEMGVWEM";

            var causa = new Faker("pt_BR");

            var faker = new Faker<Causa>("pt_BR");

            faker.CustomInstantiator(f =>
                new Causa(Guid.NewGuid(),TEXTO_COM_MAIS_DE_150_CARACTERES, TEXTO_COM_MAIS_DE_150_CARACTERES, TEXTO_COM_MAIS_DE_150_CARACTERES));

            return faker.Generate();
        }

    }
}