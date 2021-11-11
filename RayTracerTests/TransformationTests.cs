using RayTracer;
using System;
using Xunit;

namespace RayTracerTests;

public class TransformationTests
{
    [Fact]
    public void MultiplyingByTranslationMatrix()
    {
        Matrix transform = Matrix.Translation(5, -3, 2);
        RayPoint point = new(-3, 4, 5);
        Assert.Equal(new RayPoint(2, 1, 7), transform * point);
    }

    [Fact]
    public void MultiplyingByInverseTranslationMatrix()
    {
        Matrix transform = Matrix.Translation(5, -3, 2);
        Matrix inverse = Matrix.Inverse(transform);
        RayPoint point = new(-3, 4, 5);
        Assert.Equal(new RayPoint(-8, 7, 3), inverse * point);
    }

    [Fact]
    public void TranslationDoesNotAffectVectors()
    {
        Matrix transform = Matrix.Translation(5, -3, 2);
        RayVector vector = new(-3, 4, 5);
        Assert.Equal(vector, transform * vector);
    }

    [Fact]
    public void ScalingMatrixAppliedToPoint()
    {
        Matrix transform = Matrix.Scaling(2, 3, 4);
        RayPoint point = new(-4, 6, 8);
        Assert.Equal(new RayPoint(-8, 18, 32), transform * point);
    }

    [Fact]
    public void ScalingMatrixAppliedToVector()
    {
        Matrix transform = Matrix.Scaling(2, 3, 4);
        RayVector vector = new(-4, 6, 8);
        Assert.Equal(new RayVector(-8, 18, 32), vector * transform);
    }

    [Fact]
    public void MultiplyingVectorByInverseScalingMatrix()
    {
        Matrix transform = Matrix.Scaling(2, 3, 4);
        Matrix inverse = Matrix.Inverse(transform);
        RayVector vector = new(-4, 6, 8);
        Assert.Equal(new RayVector(-2, 2, 2), inverse * vector);
    }

    [Fact]
    public void ReflectionIsScalingByNegativeValue()
    {
        Matrix transform = Matrix.Scaling(-1, 1, 1);
        RayPoint point = new(2, 3, 4);
        Assert.Equal(new RayPoint(-2, 3, 4), transform * point);
    }

    [Fact]
    public void RotatingPointAroundTheXAxis()
    {
        RayPoint point = new(0, 1, 0);
        var halfQuarter = Matrix.RotationX(Math.PI / 4);
        var fullQuarter = Matrix.RotationX(Math.PI / 2);
        Assert.Equal(new RayPoint(0, Math.Sqrt(2) / 2, Math.Sqrt(2) / 2), halfQuarter * point);
        Assert.Equal(new RayPoint(0, 0, 1), fullQuarter * point);
    }

    [Fact]
    public void InverseOfXRotationRotatesInTheOppositeDirection()
    {
        RayPoint point = new(0, 1, 0);
        var halfQuarter = Matrix.RotationX(Math.PI / 4);
        var inverse = Matrix.Inverse(halfQuarter);
        Assert.Equal(new RayPoint(0, Math.Sqrt(2) / 2, -Math.Sqrt(2) / 2), inverse * point);
    }

    [Fact]
    public void RotatingPointAroundTheYAxis()
    {
        RayPoint point = new(0, 0, 1);
        var halfQuarter = Matrix.RotationY(Math.PI / 4);
        var fullQuarter = Matrix.RotationY(Math.PI / 2);
        Assert.Equal(new RayPoint(Math.Sqrt(2) / 2, 0, Math.Sqrt(2) / 2), halfQuarter * point);
        Assert.Equal(new RayPoint(1, 0, 0), fullQuarter * point);
    }

    [Fact]
    public void RotatingPointAroundTheZAxis()
    {
        RayPoint point = new(0, 1, 0);
        var halfQuarter = Matrix.RotationZ(Math.PI / 4);
        var fullQuarter = Matrix.RotationZ(Math.PI / 2);
        Assert.Equal(new RayPoint(-Math.Sqrt(2) / 2, Math.Sqrt(2) / 2, 0), halfQuarter * point);
        Assert.Equal(new RayPoint(-1, 0, 0), fullQuarter * point);
    }

    [Fact]
    public void AShearingTransformationMovesXInProportionToY()
    {
        Matrix transform = Matrix.Shearing(1, 0, 0, 0, 0, 0);
        RayPoint point = new(2, 3, 4);
        Assert.Equal(new RayPoint(5, 3, 4), transform * point);
    }
}