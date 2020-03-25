﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    public class IsabelStress{
        // Written by Isabel - used code from Team Lead 3's presentation
        // Stress test to instantiate a bunch of inventory objects
        [Test]
        public IEnumerator StressTest(){
            var T = 1/Time.deltaTime;
            SetupScene();
            for (int i = 0; i < 100; i++){
                T = 1/Time.deltaTime;
                for (int j = 0; j < 100; j++){
                    MonoBehaviour.Instantiate(Resources.Load<GameObject>("Assets/Isabel/Prefabs/Chalice"));
                }
                T = 1 / Time.deltaTime;
                Debug.Log(T);
                yield return new WaitForSeconds(1);
                if (T < 15){
                    Debug.Log((i+1) * 100);
                    if (i < 10) Assert.Fail();
                    yield break;
                }  
            }
        }

        void SetupScene(){
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Assets/Isabel/Prefabs/Chalice"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        }
    }
}
