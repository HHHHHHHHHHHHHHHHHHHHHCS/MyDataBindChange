using System.Collections;
using System.Collections.Generic;
using DataBindChange;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BindNewTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void BindNewTestTestSimplePasses()
        {
            var obj0 = new BindProperty<float>(3);
            var obj1 = new BindProperty<float>(4);
            obj0 += obj1;
            obj0.Val = 333;
            Debug.Log(obj0 + " " + obj1);
            Assert.IsTrue(obj0 == obj1);

            obj1.Val = 444;
            Debug.Log(obj0 + " " + obj1);
            Assert.IsFalse(obj0 == obj1);

            obj0 *= obj1;

            obj1.Val = 555;
            Debug.Log(obj0 + " " + obj1);
            Assert.IsTrue(obj0 == obj1);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        //        [UnityTest]
        //        public IEnumerator PropertyTestWithEnumeratorPasses()
        //        {
        //            // Use the Assert class to test conditions.
        //            // Use yield to skip a frame.
        //            yield return null;
        //        }
    }
}