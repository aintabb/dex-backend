﻿using _3_Repositories.Tests.DataGenerators;
using _3_Repositories.Tests.DataGenerators.Base;
using Models;
using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_Repositories.Tests.DataSources
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class CollaboratorDataSourceAttribute : Attribute, IParameterDataSource
    {
        private readonly IFakeDataGenerator<Collaborator> _fakeDataGenerator;
        private readonly int _amountToGenerate = 0;

        public CollaboratorDataSourceAttribute()
        {
            _fakeDataGenerator = new CollaboratorDataGenerator();
        }

        public CollaboratorDataSourceAttribute(int amount) : this()
        {
            _amountToGenerate = amount;
        }

        public IEnumerable GetData(IParameterInfo parameter)
        {
            if (_amountToGenerate <= 1)
            {
                return new[] { _fakeDataGenerator.Generate() };
            }
            List<Collaborator> collaborators = _fakeDataGenerator.GenerateRange(_amountToGenerate).ToList();
            return new[] { collaborators };
        }
    }
}
