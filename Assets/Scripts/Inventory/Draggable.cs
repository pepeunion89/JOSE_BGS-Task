using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] public RectTransform parent;
    [SerializeField] public ItemShirtSO itemShirtSO;
    [SerializeField] public Sprite transparent;
    [SerializeField] public Button btnSell;
    [SerializeField] public int idxSlot;

    private RectTransform draggableTransform;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool isNotNull = false;
    private bool dragging = true;

    private Animator animator;
    private Animator boyAnimator;
    private Transform boy;
    private SpriteRenderer boySprite;

    private void Awake() {

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    }

    public void OnPointerDown(PointerEventData eventData) {
        
        draggableTransform = eventData.pointerEnter.gameObject.GetComponent<RectTransform>();

        if(draggableTransform.GetComponent<Draggable>().itemShirtSO != null) {
            isNotNull = true;
            dragging = false;

            if (gameObject.GetComponent<Draggable>().idxSlot != 2) {

                if (btnSell.gameObject.activeSelf) {

                    btnSell.gameObject.SetActive(false);

                }
                
            }

        } else {
            Debug.Log("You are not picking anything.");
        }

    }

    public void OnPointerUp(PointerEventData eventData) {
        if (!dragging && gameObject.GetComponent<Draggable>().idxSlot != 2 && NPC.Instance.ShopIsOpened) {
            btnSell.gameObject.SetActive(true);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        
        if(isNotNull) {

            dragging = true;

            canvasGroup.blocksRaycasts = false;
            parent.SetAsLastSibling();

        } else {
            Debug.Log("You are not dragging anything.");
        }

    }

    public void OnDrag(PointerEventData eventData) {

        if (isNotNull) {

            rectTransform.anchoredPosition += eventData.delta;

        } else {
            Debug.Log("You are not dragging anything.");
        }

    }
    
    public void OnEndDrag(PointerEventData eventData) {

        if (isNotNull) {

            canvasGroup.blocksRaycasts = true;
            
            if(gameObject.transform.localPosition != Vector3.zero) {
                gameObject.transform.localPosition = Vector3.zero;

                if(gameObject.GetComponent<Draggable>().idxSlot != 2 && NPC.Instance.ShopIsOpened) {
                    btnSell.gameObject.SetActive(true);
                }

            }

        } else {
            Debug.Log("You are not dragging anything.");
        }

    }
       
    public void OnDrop(PointerEventData eventData) {

        if (eventData.pointerDrag.gameObject.GetComponent<Draggable>().itemShirtSO != null/*.isNotNull*/) {

            List<ItemShirtSO> itemShirtSOList = Player.Instance.GetInventory().GetItemShirtList();

            int idxDropped = eventData.pointerDrag.gameObject.GetComponent<Draggable>().idxSlot;
            int idxChanged = gameObject.GetComponent<Draggable>().idxSlot;

            GameObject droppedObject = eventData.pointerDrag;

            if(droppedObject != null) {

                if(idxDropped == 2 || idxChanged == 2) {

                    boy = Player.Instance.boy;
                    boyAnimator = boy.GetComponent<Animator>();
                    boySprite = boy.GetComponent<SpriteRenderer>();

                    if (idxDropped == 2) {

                        if(gameObject.GetComponent<Image>().sprite.name == "transparent") {

                            animator = AnimatorManager.Instance.GreenAnimation;
                            boySprite.sprite = AnimatorManager.Instance.GreenSprite;
                            

                        } else {

                            if(gameObject.GetComponent<Draggable>().itemShirtSO.itemShirtName == "ManchesterCityShirt") {

                                animator = AnimatorManager.Instance.ManchesterCityAnimation;
                                boySprite.sprite = AnimatorManager.Instance.ManchesterCitySprite;

                            } else {

                                animator = AnimatorManager.Instance.ManchesterUnitedAnimation;
                                boySprite.sprite = AnimatorManager.Instance.ManchesterUnitedSprite;

                            }

                        }

                    } else {

                        if (droppedObject.GetComponent<Draggable>().itemShirtSO.itemShirtName == "ManchesterCityShirt") {

                            animator = AnimatorManager.Instance.ManchesterCityAnimation;
                            boySprite.sprite = AnimatorManager.Instance.ManchesterCitySprite;

                        } else {

                            animator = AnimatorManager.Instance.ManchesterUnitedAnimation;
                            boySprite.sprite = AnimatorManager.Instance.ManchesterUnitedSprite;

                        }

                    }

                    boyAnimator.runtimeAnimatorController = animator.runtimeAnimatorController;

                }

                if(gameObject.GetComponent<Draggable>().itemShirtSO == null) {

                    gameObject.GetComponent<Draggable>().itemShirtSO = droppedObject.GetComponent<Draggable>().itemShirtSO;
                    gameObject.GetComponent<Image>().sprite = droppedObject.GetComponent<Draggable>().itemShirtSO.sprite;

                    droppedObject.GetComponent<RectTransform>().localPosition = Vector2.zero;
                    droppedObject.GetComponent<Draggable>().itemShirtSO = null;
                    droppedObject.GetComponent<Image>().sprite = transparent;

                } else {

                    ItemShirtSO isSOAux = gameObject.GetComponent<Draggable>().itemShirtSO;

                    gameObject.GetComponent<Draggable>().itemShirtSO = droppedObject.GetComponent<Draggable>().itemShirtSO;
                    gameObject.GetComponent<Image>().sprite = droppedObject.GetComponent<Draggable>().itemShirtSO.sprite;

                    droppedObject.GetComponent<RectTransform>().localPosition = Vector2.zero;
                    droppedObject.GetComponent<Draggable>().itemShirtSO = isSOAux;
                    droppedObject.GetComponent<Image>().sprite = isSOAux.sprite;

                }

                ItemShirtSO isSOA = itemShirtSOList[idxDropped];
                itemShirtSOList[idxDropped] = itemShirtSOList[idxChanged];
                itemShirtSOList[idxChanged] = isSOA;

                InventoryUI.Instance.RefreshInventory(itemShirtSOList);

            }

        } else {

            if (gameObject.GetComponent<Draggable>().btnSell != null) {
                gameObject.GetComponent<Draggable>().btnSell.gameObject.SetActive(false);
            }
            Debug.Log("You are not dropping anything.");

        }

    }

}
