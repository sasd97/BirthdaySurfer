using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDetector : MonoBehaviour {

    private static List<Rule<string>> rules = new List<Rule<string>>() {
        new SpawnBarriersRule()
    };

    void OnTriggerExit(Collider col) {
        foreach (var rule in rules) {
            if (rule.IsApplicable(col.tag)) rule.Apply();
        }
    }
}
