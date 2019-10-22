﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BluePro.Skill
{
    public class CommonParam
    {
        public CommonParam()
        {
        }

        public CommonParam(ISkillActor actor)
        {
            this.actorClicked = actor;
        }

        private bool isBuff; //buff系统使用的参数
        private int identifyId; //每个释放的技能和技能参数的标志ID（每启动一次技能 ID++） 
        private bool isBounce; //是否是弹射状态
        private Vector3 postion; //点击的目标Point位置
        private List<ISkillActor> targets; //技能作用的所有目标
        private ISkillActor actorClicked; //施法者点击目标
        public bool IsBuff => isBuff;
        public int IdentifyId => identifyId;
        public bool IsBounce => isBounce;
        public Vector3 Postion => postion;
        public List<ISkillActor> Targets => targets;
        public ISkillActor ActorClicked => actorClicked;

        public void SetIdentifyId(int id, bool isBuff)
        {
            this.identifyId = id;
            this.isBuff = isBuff;
        }

        public void SetPosition(Vector3 postion)
        {
            this.postion = postion;
        }

        public bool HasTargets()
        {
            return targets != null && targets.Count > 0;
        }

        public void ResetTarget()
        {
            targets?.Clear();
        }

        public void AddTarget(ISkillActor actor)
        {
            if (actor == null)
            {
                SkillUtil.LogError("[SkillParam] target is null");
                return;
            }

            if (targets == null)
                targets = new List<ISkillActor>();

            targets.Add(actor);
        }

        public void AddTargets(ISkillActor[] target)
        {
            if (target == null)
            {
                SkillUtil.LogError("[SkillParam] target arrary is null");
                return;
            }

            if (targets == null)
                targets = new List<ISkillActor>();

            targets.AddRange(target.ToList());
        }

        //*********弹射相关**************//

        private BounceParam bounceParam; //弹射参数

        public BounceParam BounceParam => bounceParam ?? (bounceParam = new BounceParam());

        public void SetBounceState(bool bBounce, int actionId, int searchActionId)
        {
            this.isBounce = bBounce;
            this.BounceParam.SetBounceState(bBounce, actionId, searchActionId);
        }
    }
}