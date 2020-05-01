using System.Collections;
using System.Collections.Generic;
using DataBindChange;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace Tests
{
    public class BindTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void BindTestSimplePasses()
        {
            var obj0 = new BindAuto<float>(3);
            var obj1 = new BindCustomFloat(4);
            new BindHandler().BindProperty(() => obj1.Val = obj0.Val);
            new BindHandler().BindProperty(() => obj0.Val = obj1.Val);

            obj1.Val = 5f;
            Debug.Log(obj0.Val + " , "+obj1.Val);
            Assert.IsTrue(obj0.Val==obj1.Val);
            obj1.Val = 7f;
            Debug.Log(obj0.Val + " , " + obj1.Val);
            Assert.IsTrue(obj0.Val == obj1.Val);
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