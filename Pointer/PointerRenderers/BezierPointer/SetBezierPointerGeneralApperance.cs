// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Pointer")]
	[Tooltip("Set Bezier Pointer general apperance and colors.")]

	public class  SetBezierPointerGeneralApperance : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_BezierPointerRenderer))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Set pointer hit laser color.")]
		[TitleAttribute("Valid Collision Color")]
		public FsmColor hitcolorlazer;

		[Tooltip("Set pointer miss laser color.")]
		[TitleAttribute("Invalid Collision Color")]
		public FsmColor misscolorlazer;

		[ObjectType(typeof(VRTK.VRTK_BezierPointerRenderer.VisibilityStates))]
		public FsmEnum tracerVisibility;

		[ObjectType(typeof(VRTK.VRTK_BezierPointerRenderer.VisibilityStates))]
		public FsmEnum cursorVisibility;

		public FsmBool everyFrame;

		VRTK.VRTK_BezierPointerRenderer theScript;

		public override void Reset()
		{

			gameObject = null;
			hitcolorlazer = null;
			tracerVisibility = null;
			cursorVisibility = null;
			misscolorlazer = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_BezierPointerRenderer>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.validCollisionColor = hitcolorlazer.Value;
			theScript.invalidCollisionColor = misscolorlazer.Value;
			theScript.tracerVisibility = (VRTK.VRTK_BezierPointerRenderer.VisibilityStates)tracerVisibility.Value;
			theScript.cursorVisibility = (VRTK.VRTK_BezierPointerRenderer.VisibilityStates)cursorVisibility.Value;

		}

	}
}