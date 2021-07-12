using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Vector3 wallsize = new Vector3(10.0f, 2.0f, 1.0f);

    private void OnDrawGizmos()
    {
        if (this.transform.childCount < 2)
        {
            return;
        }

        //line: curr to next
        for (int i = 0; i < this.transform.childCount - 1; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(this.transform.GetChild(i).position, this.transform.GetChild(i + 1).position);
        }

        //line: last to first
        int idxlast = this.transform.childCount - 1;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.GetChild(idxlast).position, this.transform.GetChild(0).position);
    }
    public void AngleCheckpointsWalls()
    {
        Transform prev = null;
        Transform curr = null;
        Transform next = null;
        int idxLast = this.transform.childCount - 1;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //curr, next
            if (i == 0)
            {
                prev = this.transform.GetChild(idxLast);
                curr = this.transform.GetChild(i);
                next = this.transform.GetChild(i + 1);
            }
            else if (i == idxLast)
            {
                prev = this.transform.GetChild(i - 1);
                curr = this.transform.GetChild(i);
                next = this.transform.GetChild(0);
            }
            else
            {
                prev = this.transform.GetChild(i - 1);
                curr = this.transform.GetChild(i);
                next = this.transform.GetChild(i + 1);
            }

            //size wall
            curr.localScale = wallsize;

            //angle wall (half way between "next checkpoint" & inverse(opposite) of "prev checkpoint")
            //curr.LookAt(prev);
            //Quaternion prevRot = new Quaternion(curr.transform.rotation.x, curr.transform.rotation.y, curr.transform.rotation.z, curr.transform.rotation.w);
            //Quaternion prevRot180 = Quaternion.Euler(-prevRot.eulerAngles);
            curr.LookAt(next);
            //Quaternion nextRot = new Quaternion(curr.transform.rotation.x, curr.transform.rotation.y, curr.transform.rotation.z, curr.transform.rotation.w);
            //curr.rotation = Quaternion.Lerp(nextRot, prevRot180, 0.5f);
        }
    }

}