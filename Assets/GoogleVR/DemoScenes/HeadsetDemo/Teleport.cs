// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {

  void Start() {
    
  }

  void LateUpdate() {
    
  }
	void OnCollisionEnter () {
		//set score
		GameController.Instance.addScore(10);
		TeleportRandomly ();
	}

  public void TeleportRandomly() {
    Vector3 direction = Random.onUnitSphere;
    direction.y = Mathf.Clamp(direction.y, 0.5f, 1.5f);
    float distance = 5 * Random.value + 3.5f;
    transform.localPosition = direction * distance;
  }
}
