using Xunit;
using MeuApp;

public class SomaTests
{
	[Fact]
	public void TestarSoma()
	{
		var calc = new Calculadora();
		Assert.Equal(5, calc.Somar(2, 3));
	}
}