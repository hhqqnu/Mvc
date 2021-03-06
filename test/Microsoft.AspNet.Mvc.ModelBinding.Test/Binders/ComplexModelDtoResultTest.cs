// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.AspNet.Mvc.ModelBinding.Test
{
    public class ComplexModelDtoResultTest
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            var validationNode = GetValidationNode();

            // Act
            var result = new ComplexModelDtoResult(
                "some string", 
                isModelBound: true, 
                validationNode: validationNode);

            // Assert
            Assert.Equal("some string", result.Model);
            Assert.True(result.IsModelBound);
            Assert.Equal(validationNode, result.ValidationNode);
        }

        private static ModelValidationNode GetValidationNode()
        {
            var provider = new EmptyModelMetadataProvider();
            var metadata = provider.GetMetadataForType(null, typeof(object));
            return new ModelValidationNode(metadata, "someKey");
        }
    }
}
