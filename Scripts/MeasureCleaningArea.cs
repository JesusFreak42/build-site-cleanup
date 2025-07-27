using UnityEngine;

public class MeasureCleaningArea : MonoBehaviour
{

    [SerializeField] private LayerMask edibleLayers;
    [SerializeField] private ProgressBar progressBar;
    private int initialDirtiness = 0;
    private int dirtiness = 0;
    [SerializeField] private UIHandler uiHandler;

    private void Start()
    {
        //measure how many edible objects are inside this box's area
        Collider[] edibles = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, edibleLayers);
        initialDirtiness = edibles.Length;
        dirtiness = initialDirtiness;
        SetProgressBar(); //set the progress bar accordingly
    }

    private void OnTriggerExit(Collider other)
    { //when an object leaves this box's area, recalculate the dirtiness still to be cleaned up
        Collider[] edibles = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, edibleLayers);
        dirtiness = edibles.Length;
        SetProgressBar();
        
        //check if the player won the game
        if (progressBar.GetValue() >= progressBar.GetMaxValue())
        {
            uiHandler.WinGame();
        }
    }

    private void SetProgressBar()
    {
        if (progressBar == null || initialDirtiness == 0) return;

        // progressBar.SetValue(dirtiness / initialDirtiness); //progress bar go down (show dirtiness)
        progressBar.SetValue((float) (initialDirtiness - dirtiness) / initialDirtiness); //progress bar go up (show cleanliness)
    }

}
