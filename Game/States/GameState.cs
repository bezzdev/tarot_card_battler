using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Core.Statemachines;
using tarot_card_battler.Game.GameLoop;
using tarot_card_battler.Game.PlayArea;

namespace tarot_card_battler.Game.States
{
    public class GameState : State
    {
        public StateMachine gameLoop;
        public Board board;
        public CardTooltip cardTooltip = new CardTooltip();

        public GameState() {
            PlayerBoard player = new PlayerBoard("player");
            player.deck.position.x = 1060;
            player.deck.position.y = 140;

            player.hand.position.x = 600;
            player.hand.position.y = -54;

            player.field.position.x = 600;
            player.field.position.y = 221;

            player.candle.position.x = 140;
            player.candle.position.y = 140;

            player.playerStats.position.x = 10;
            player.playerStats.position.y = 280;
            player.playerStats.renderStats = true;


            player.discards.position.x = player.candle.position.x;
            player.discards.position.y = player.candle.position.y;

            PlayerBoard opponent = new PlayerBoard("opponent");
            opponent.deck.position.x = 140;
            opponent.deck.position.y = 580;

            opponent.hand.position.x = 600;
            opponent.hand.position.y = 854;
            opponent.hand.faceup = false;

            opponent.field.position.x = 600;
            opponent.field.position.y = 579;

            opponent.playerStats.position.x = 940; 
            opponent.playerStats.position.y = 720;
            opponent.playerStats.renderStats = true;

            opponent.candle.position.x = 1060;
            opponent.candle.position.y = 580;

            opponent.discards.position.x = opponent.candle.position.x;
            opponent.discards.position.y = opponent.candle.position.y;

            player.opponent = opponent;
            opponent.opponent = player;

            board = new Board()
            {
                player = player,
                players = new List<PlayerBoard>()
                {
                    player,
                    opponent
                }
            };

            gameLoop = new StateMachine(new SetupState(board, 0));

            new InteractionManager(board);
        }

        public override void Update()
        {
            gameLoop.Update();
            board.Update();

            InteractionManager.instance.Update();
            cardTooltip.Update();

            if (Raylib.IsKeyPressed(KeyboardKey.Escape))
            {
                stateMachine.SetState(new MenuState());
            }
        }
        public override void Render()
        {
            Raylib.DrawTexture(References.GameBackground, 0, 0, Color.White);

            EntityLayerManager.RenderLayer(-2);
            gameLoop.EarlyRender();
            EntityLayerManager.RenderLayer(-1);
            board.EarlyRender();

            EntityLayerManager.RenderLayer(0);

            gameLoop.Render();
            EntityLayerManager.RenderLayer(1);

            board.Render();
            EntityLayerManager.RenderLayer(2);
        }
    }
}
