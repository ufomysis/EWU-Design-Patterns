/**
 * Title:
 * Description:
 * Copyright:    Copyright (c) 2001
 * Company:
 * @author
 * @version 1.0
 */

public class Thief extends Hero
{

    public Thief()
	{
		super("Thief", 75, 6, .8, 20, 40, .5, new MoveSurpriseAttack(), "Surprise Attack");


    }//end constructor
    
    public Thief(String name)
	{
		super(name, 75, 6, .8, 20, 40, .5, new MoveSurpriseAttack(), "Surprise Attack");

    }//end constructor

	public void surpriseAttack(DungeonCharacter opponent)
	{
		double surprise = Math.random();
		if (surprise <= .4)
		{
			System.out.println("Surprise attack was successful!\n" +
								name + " gets an additional turn.");
			numTurns++;
			attack(opponent);
		}//end surprise
		else if (surprise >= .9)
		{
			System.out.println("Uh oh! " + opponent.getName() + " saw you and" +
								" blocked your attack!");
		}
		else
		    attack(opponent);


	}//end surpriseAttack method


	public void specialMove(DungeonCharacter opponent){
		specialMove.execute(this, opponent);
		numTurns--;
	}
}