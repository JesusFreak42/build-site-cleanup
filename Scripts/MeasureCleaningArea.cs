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
        Collider[] edibles = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, edibleLayers);
        initialDirtiness = edibles.Length;
        dirtiness = initialDirtiness;
        SetProgressBar();
    }

    private void OnTriggerExit(Collider other)
    {
        Collider[] edibles = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, edibleLayers);
        dirtiness = edibles.Length;
        SetProgressBar();
        
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
