
public interface InvestigationYields
{
    /// <summary>
    /// launch the animation for when this event is revealed
    /// called during reveal phase
    /// </summary>
    void DisplayAction();

    /// <summary>
    /// modify the Lead in some way
    /// called during reveal phase
    /// </summary>
    void ModifyLead(Lead target);

    /// <summary>
    /// change the investigator's time remaining
    /// called during resolution phase
    /// </summary>
    /// <returns>the change in time this event gives </returns>
    int ModifyTimeLeft();

    /// <summary>
    /// change the investigator's agents remaining for the next day
    /// called during resolution phase
    /// </summary>
    /// <returns>the change in pips this event gives  for the next day</returns>
    int ModifyPips();

}