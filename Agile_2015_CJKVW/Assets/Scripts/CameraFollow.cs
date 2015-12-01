using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float distanceFromPlayer;
	public float cameraHeight = 5;

	public Transform cameraTarget;

	Vector3 startLoc;
	Vector3 endLoc;
	public float smooth = 5.0f;

    //RaycastHit[] vampires;
    //public Material originalMat;
    //public Material newMat;

	// Use this for initialization
	void Start () {
		transform.position = FindPos ();
		transform.LookAt (cameraTarget);
        //float dist = Mathf.Sqrt(cameraHeight * cameraHeight + distanceFromPlayer * distanceFromPlayer);
        //vampires = Physics.RaycastAll(transform.position, cameraTarget.position - transform.position, dist);
    }
	
	// Update is called once per frame
	void Update () {
		Follow ();	
	    //Obfuscate ();
	}

	void Follow(){
		startLoc = transform.position;
		endLoc = FindPos ();
		transform.position = Vector3.Lerp (startLoc, endLoc, Time.deltaTime * smooth);
	}

	/*
	void UpdateLook()
	{
		Vector3 relativePos = cameraTarget.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (relativePos);
		rotation.y = 0;
		rotation.z = 0;
		transform.rotation = Quaternion.Lerp (transform.rotation,
		                                      rotation,
		                                      Time.deltaTime);
	}*/

	Vector3 FindPos()
	{
		return new Vector3(
			cameraTarget.position.x,
			(cameraTarget.position.y + cameraHeight),
			(cameraTarget.position.z - distanceFromPlayer));
	}
    /*
	void Obfuscate()
	{
		if (vampires.Length > 0 || vampires != null) {
			foreach(RaycastHit kindred in vampires)
			{
				Renderer ghoul = kindred.transform.gameObject.GetComponent<Renderer>();

                if(ghoul.material == newMat)
                {
                    ghoul.material = originalMat;
                }
                //Color color = ghoul.material.color;
                //color.a = 1.0f;
                //ghoul.material.SetColor("_SpecColor",color);
			}
		}

		float dist = Mathf.Sqrt (cameraHeight * cameraHeight + distanceFromPlayer * distanceFromPlayer);
		vampires = Physics.RaycastAll (transform.position, cameraTarget.position - transform.position, dist);

        if (vampires.Length > 0 || vampires != null)
        {
            foreach (RaycastHit kindred in vampires)
            {
                Renderer ghoul = kindred.transform.gameObject.GetComponent<Renderer>();

                if (ghoul.material == originalMat)
                {
                    ghoul.material = newMat;
                }
                //Color color = ghoul.material.color;
                //color.a = 0.5f;
                //ghoul.material.SetColor("_SpecColor", color);
                //Debug.Log("Obfuscate");
            }
        }
    }
    //*/
}





