// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Interaction")]
	[Tooltip("Sets interactable object grab settings.")]

	public class  SetInteractableObjectGrabOptions : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_InteractableObject))]    
		public FsmOwnerDefault gameObject;

		public FsmBool isGrabbable;
		public FsmBool holdButtonToGrab;
		public FsmBool stayGrabbedOnTeleport;

		[ObjectType(typeof(VRTK.VRTK_InteractableObject.ValidDropTypes))]
		public FsmEnum validDrop;

		[ObjectType(typeof(VRTK.VRTK_ControllerEvents.ButtonAlias))]
		public FsmEnum grabOverrideButton;

		[ObjectType(typeof(VRTK.VRTK_InteractableObject.AllowedController))]
		public FsmEnum allowedGrabController;

		public FsmBool everyFrame;

		VRTK.VRTK_InteractableObject theScript;

		public override void Reset()
		{

			isGrabbable = false;
			holdButtonToGrab = false;
			stayGrabbedOnTeleport = false;
			grabOverrideButton = null;
			allowedGrabController = null;
			validDrop = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_InteractableObject>();

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

			theScript.isGrabbable = isGrabbable.Value;
			theScript.holdButtonToGrab = holdButtonToGrab.Value;
			theScript.stayGrabbedOnTeleport = stayGrabbedOnTeleport.Value;
			theScript.validDrop = (VRTK.VRTK_InteractableObject.ValidDropTypes)validDrop.Value;
			theScript.grabOverrideButton = (VRTK.VRTK_ControllerEvents.ButtonAlias)grabOverrideButton.Value;
			theScript.allowedGrabControllers = (VRTK.VRTK_InteractableObject.AllowedController)allowedGrabController.Value;
		}

	}
} 