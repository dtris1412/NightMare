using System.Collections;
using System.Collections.Generic;
using TMPro;
/*using UnityEditor.Media;*/
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject continueButton;

    // Mảng 2 chiều cho các đối thoại của các sự kiện khác nhau
    public string[][] dialogues;
    private bool[] eventTriggered; // Mảng để theo dõi các sự kiện đã xảy ra

    private int eventIndex = 0;
    private int dialogueIndex = 0;
    private float wordSpeed = 0.06f;
    private QuestManagerment quest;
    private int questCount = 1;
    public AudioSource aus;
    public AudioClip keyboard;

    Player player;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(aus);
        quest = FindObjectOfType<QuestManagerment>();
        player = FindObjectOfType<Player>();
        //aus = GetComponent<AudioSource>();

        // Khởi tạo mảng 2 chiều cho các đối thoại của từng sự kiện
        dialogues = new string[][]
        {
            new string[] { "Cuoi cung thi da den noi roi, met that", "Khong biet ngoi nha do dang o noi nao day" },//0
            new string[] { "O day co nuoi meo sao", "Toi nghiep, chac lau qua may chua duoc an dung khong" },//1
            new string[] { "Wow, phong ngu nay day du tien nghi luon", "That la tot cho mot sinh vien nhu minh", "Cat do dat va bat dau hoc bai thoi","Cong tat den o dau ta" },//2
            new string[] { "Quai la, sao no khong giong nhu thuong ngay", "Cac chu tren day la ham y gi co chu", "Co tieng nuoc chay","Khoan da, minh la vao nha ve sinh lan nao dau","Phai di kiem tra thoi" },//3
            new string[] { "Ch...ch...chuyen quai gi dang dien ra vay", "Co le do minh hoa mat thoi, met roi", "Co le nen kiem tra lai lan nua roi han di ngu" },//4
            new string[] { "Cai quai gi vay", "ro rang la minh nghe duoc tieng buoc chan va tieng cua da mo roi ma", "Chac chi la giac mo ma thoi, phai di rua mat cho tinh tao" },//5
            new string[] { ".....", "Nhung dong chu nay tu dau xuat hien vay", "Chuyen quai quy gi dang dien ra trong can nha nay vay","Khoan da, Laptop cua minh co thong bao moi sao, " +
            "minh da tat no roi ma","Voi nhung chuyen quai quy dang dien ra nay thi co le minh nen kiem tra may van hon" },//6
            new string[] { "Day la mot ma morse sao", "Tai sao no lai co the tu tai ve co chu","Cu giai ma no ra truoc da" },//7
            new string[] { "BASEMENT...", "La tang ham sao, lam gi co tang ham nao o day", "Chac han trong can phong nay rat nhieu thu bi an" },//8
            new string[] { "No can den password de in ra sao", "Co le se lien quan gi do den file WinRar kia", "Phai xem lai thoi" },//9
            new string[] { "Ca...cai gi the nay", "Nhung thu nay....", "Kh....khong le no....." },//10
            /*new string[] { "Alphabet...", "Chang le la tu chu NIGHTMARE ma minh day thay sao", "Cat do dat va bat dau hoc bai thoi" },//10*/
            new string[] { "Da co duoc mat khau roi, quay lai may in thoi" },//11
            new string[] { "Day la ban do cua can phong sao", "Hinh nhu co danh dau gi tren do", "Thu di tim xem sao" },//12
            new string[] { "Ngac nhien that, khong ngo trong can phong ngu lai co mot loi vao tang ham nhu the nay" },//13
             new string[] { "Tang ham nay toi that, lieu se co chuyen gi da xay ra o day" },//14
            new string[] { "D...d... day la gi!", "La xac nguoi sao", "Cac bo phan da bi phan tach ra", "Nhung khi tai sao khi minh buoc vao vong tron nay thi no lai xuat hien co chu",
                            "Chang le canh bao minh dieu gi chan","Khoan da!...tam ban do... no co danh so thu tu...chang le...", "Co le do la so thu tu cua cac bo phan co the"},//15
            new string[] { "Alphabet...nhung la cua cai gi","Chang le la co lien quan den ky tu mau o trong nha ve sinh hay sao" ,"...N...I...G...H...T...M...A...R...E..." },//16
            new string[] { "Dung that la do minh hoa mat roi","Lam sao co the co chuyen do duoc chu", "Co the di ngu duoc roi" },//17

            // Thêm các sự kiện và đối thoại khác vào đây
        };

        // Khởi tạo mảng để theo dõi các sự kiện đã xảy ra
        eventTriggered = new bool[dialogues.Length];
    }

    private void Update()
    {
        if (dialogueText.text == dialogues[eventIndex][dialogueIndex])
        {
            continueButton.SetActive(true);
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        dialogueIndex = 0;
        dialoguePanel.SetActive(false);
        player.canMove = true;
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogues[eventIndex][dialogueIndex].ToCharArray())
        {
            dialogueText.text += letter;
            if(keyboard!= null)
            {
                aus.PlayOneShot(keyboard);
            }
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        continueButton.SetActive(false);
        if (dialogueIndex < dialogues[eventIndex].Length - 1)
        {
            dialogueIndex++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();

        }
    }



    public void StartEventDialogue(int newEventIndex)
    {
        if (!eventTriggered[newEventIndex])
        {
            eventIndex = newEventIndex;
            dialogueIndex = 0;
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
            eventTriggered[newEventIndex] = true; // Đánh dấu sự kiện này đã xảy ra
            
            player.canMove = false;
        }
    }
}
