﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using ReactSystem;
using Connector;
namespace ReactSystem
{

    /// <summary>
    /// 负责实验的初始化，加载元素，重置元素
    /// </summary>
    public class ReactSystemBehaiver : MonoBehaviour
    {
        public ReactGroupObj experimentData;

        public Button startBtn;
        public Button interactBtn;
        public Button nextBtn;

        private ReactSystemCtrl _systemCtrl;
        public ConnectorCtrl groupParent;
        void Start()
        {
            startBtn.onClick.AddListener(RestartExperiment);
            interactBtn.onClick.AddListener(StartExperiment);
            nextBtn.onClick.AddListener(NextStep);

            _systemCtrl = new ReactSystemCtrl();
            _systemCtrl.GetConnectedDic = GetConnectedDic;
            _systemCtrl.InitExperiment(experimentData.elements);
            _systemCtrl.onComplete += () => { Debug.Log("Complete"); };
            _systemCtrl.onStepBreak += (x) => { Debug.Log("StepBreak" + x.Go.name); };

            RestartExperiment();
        }
        private void Update()
        {
            groupParent.Update();
        }
        Dictionary<IContainer, int> GetConnectedDic(IContainer item, int exportID)
        {
            var dic = new Dictionary<IContainer, int>();
            var nodeParent = item.Go.GetComponent<IPortParent>();
            List<IPortItem> nodeItems = null;
            if (groupParent.ConnectedDic.TryGetValue(nodeParent, out nodeItems))
            {
                var nodeItem = nodeItems.Find(x => x.NodeID == exportID);
                if (nodeItem != null)
                {
                    var connectedItem = nodeItem.ConnectedNode.Body;
                    var body = connectedItem.Trans.GetComponent<IContainer>();
                    var id = nodeItem.ConnectedNode.NodeID;
                    dic[body] = id;

                }
            }
            return dic;
        }

        void RestartExperiment()
        {
            _systemCtrl.ReStart();
            groupParent.Start();
        }

        void StartExperiment()
        {
            var ok = _systemCtrl.TryStartProducer();
            if (!ok)
            {
                Debug.LogError("启动失败");
            }
        }

        void NextStep()
        {
            _systemCtrl.TryNextContainer();
        }
    }
}