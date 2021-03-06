// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions

#if VRTK_VERSION_3_2_0_OR_NEWER

{
	[ActionCategory("VRTKController")]
	[Tooltip("Get grab pressed event for VRTK.")]

	public class  GetGrabPressed : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_InteractGrab))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("This will be true if the button aliased to the grab is held down.")]
		public FsmBool grabPressed;

		public FsmBool everyFrame;

		VRTK_InteractGrab theScript;

		public override void Reset()
		{

			grabPressed = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_InteractGrab>();

			MakeItSo();

			if (!everyFrame.Value)
			{
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

			grabPressed.Value = theScript.IsGrabButtonPressed();
		}

	}
}

#else

{
[ActionCategory("VRTKController")]
[Tooltip("Get grab pressed event for VRTK.")]

public class  GetGrabPressed : FsmStateAction

{
[RequiredField]
[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
public FsmOwnerDefault gameObject;

[Tooltip("This will be true if the button aliased to the grab is held down.")]
public FsmBool grabPressed;

public FsmBool everyFrame;

VRTK.VRTK_ControllerEvents theScript;

public override void Reset()
{

grabPressed = false;
gameObject = null;
everyFrame = false;
}

public override void OnEnter()
{
var go = Fsm.GetOwnerDefaultTarget(gameObject);

theScript = go.GetComponent<VRTK.VRTK_ControllerEvents>();

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

grabPressed.Value = theScript.grabPressed;

}

}
}

#endif