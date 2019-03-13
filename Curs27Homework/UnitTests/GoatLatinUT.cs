using Curs27Homework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class GoatLatinUT
    {
        private GoatLatin goatLatin;

        [SetUp]
        public void Setup()
        {
            goatLatin = new GoatLatin();
        }

        [Test]
        public void Translate()
        {
            //arrange
            var input = "I speak Goat Latin";
            var expected = "Imaa peaksmaaa oatGmaaaa atinLmaaaaa";

            //act
            var actual = goatLatin.Translate(input);

            //assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase("The quick brown fox jumped over the lazy dog", 
            ExpectedResult = "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa")]
        [TestCase("Ana are mere", 
            ExpectedResult = "Anamaa aremaaa eremmaaaa")]
        [TestCase("Miercuri e ziua de mijloc a saptamanii de lucru", 
            ExpectedResult = "iercuriMmaa emaaa iuazmaaaa edmaaaaa ijlocmmaaaaaa amaaaaaaa aptamaniismaaaaaaaa edmaaaaaaaaa ucrulmaaaaaaaaaa")]
        public string TranslateTestCases(string s)
        {
            //arrange
            var input = s;

            //act
            return goatLatin.Translate(input);
        }

        [Test]
        public void ThrowExceptionWhenInputIsEmpty()
        {
            //arrange
            var input = "";

            //assert
            Assert.Throws<InvalidOperationException>(()=>goatLatin.Translate(input));
        }
    }
}
