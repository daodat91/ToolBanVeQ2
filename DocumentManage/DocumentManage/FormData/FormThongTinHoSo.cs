using DAL.ManageDocument.EntityClasses;
using DAL.ManageDocument.HelperClasses;
using DocumentManage.Object;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DocumentManage
{
    public partial class FormThongTinHoSo : DockContent
    {
        private Dictionary<long, ThongTinHoSo> _dictHoSo;
        private long _rootId = 0;

        private Dictionary<int, string> _dictLoaiGiayToFileScan;

        private Font font = new Font("Tahoma", 9f, FontStyle.Bold);

        private FormNhapHoSo frmNhapHoSo;

        private FormTimKiem frmTimKiem;
        public FormThongTinHoSo()
        {
            InitializeComponent();
            SetDictLoaiGiayToFileScan();
        }

        private void SetDictLoaiGiayToFileScan()
        {
            EntityCollection entityCollection = ManageBase.SelectAllLoaiGiayTo(1);
            this._dictLoaiGiayToFileScan = new Dictionary<int, string>();
            foreach (LoaiGiayToEntity loaiGiayToEntity in entityCollection)
            {
                this._dictLoaiGiayToFileScan.Add(loaiGiayToEntity.LoaiGiayToId, loaiGiayToEntity.TenLoaiGiayTo);
            }
        }

        private void SaveThongTinHoSo(long thongTinHoSoId, long khoaChaId, ChiTietHoSo value)
        {
            ThongTinHoSoEntity thongTinHoSoEntity = new ThongTinHoSoEntity();
            thongTinHoSoEntity.ThongTinHoSoId = thongTinHoSoId;
            thongTinHoSoEntity.KhoaChaId = new long?(khoaChaId);
            thongTinHoSoEntity.ChiTietHoSo = JsonConvert.SerializeObject(value);
        }

        private void hideTreeNode(TreeNode node)
        {
            bool flag = node.Tag == null || !node.Tag.ToString().Contains("ID");
            if (flag)
            {
                node.HideCheckBox();
            }
            bool flag2 = node.Nodes != null;
            if (flag2)
            {
                foreach (TreeNode node2 in node.Nodes)
                {
                    this.hideTreeNode(node2);
                }
            }
        }

        private TreeNode AddData2TreeNode(ThongTinHoSo hoSoInfo)
        {
            string text = "";
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            bool flag = hoSoInfo.ThongTinChiTiet.ListThua != null;
            if (flag)
            {
                foreach (ThuaDat current in hoSoInfo.ThongTinChiTiet.ListThua)
                {
                    bool flag2 = !list.Contains(current.SoThuTuThua);
                    if (flag2)
                    {
                        list.Add(current.SoThuTuThua);
                    }
                    bool flag3 = !list2.Contains(current.SoHieuToBanDo);
                    if (flag3)
                    {
                        list2.Add(current.SoHieuToBanDo);
                    }
                }
                text = " thửa đất số " + string.Join(",", list) + " tờ " + string.Join(",", list2);
            }
            bool flag4 = hoSoInfo.ThongTinChiTiet.ListNha != null;
            if (flag4)
            {
                list = new List<string>();
                foreach (Nha current2 in hoSoInfo.ThongTinChiTiet.ListNha)
                {
                    bool flag5 = current2.LaCanHo && current2.SoNha != "" && !list.Contains(current2.SoNha.ToString());
                    if (flag5)
                    {
                        list.Add(current2.SoNha.ToString());
                    }
                }
                bool flag6 = list.Count > 0;
                if (flag6)
                {
                    bool flag7 = text == "";
                    if (flag7)
                    {
                        text = " căn hộ " + string.Join(",", list);
                    }
                    else
                    {
                        text = text + "; căn hộ " + string.Join(",", list);
                    }
                }
            }
            string text2 = "";
            bool flag8 = !string.IsNullOrEmpty(hoSoInfo.NguoiCapNhat);
            if (flag8)
            {
                text2 += hoSoInfo.NguoiCapNhat;
            }
            DateTime? dateTime = hoSoInfo.NgayChinhSua;
            bool hasValue = dateTime.HasValue;
            if (hasValue)
            {
                string arg_236_0 = text2;
                string arg_236_1 = " cập nhật ngày ";
                dateTime = hoSoInfo.NgayChinhSua;
                text2 = arg_236_0 + arg_236_1 + (dateTime.HasValue ? dateTime.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss") : null);
            }
            TreeNode treeNode = new TreeNode(string.Concat(new string[]
            {
                "Hồ sơ bản vẽ",
                text,
                "; ",
                GlobalVariable.TenXa,
                "; ",
                text2,
                "                    "
            }));
            treeNode.Tag = "ID" + hoSoInfo.ThongTinHoSoId;
            treeNode.NodeFont = this.font;
            List<string> list3 = new List<string>();
            bool flag9 = !string.IsNullOrEmpty(hoSoInfo.SoBienNhan);
            if (flag9)
            {
                list3.Add("Số biên nhận: " + hoSoInfo.SoBienNhan);
            }
            bool flag10 = !string.IsNullOrEmpty(hoSoInfo.SoBanVe);
            if (flag10)
            {
                list3.Add("Số bản vẽ: " + hoSoInfo.SoBanVe);
            }
            dateTime = hoSoInfo.NgayNop;
            bool hasValue2 = dateTime.HasValue;
            if (hasValue2)
            {
                List<string> arg_352_0 = list3;
                string arg_34D_0 = "Ngày nộp: ";
                dateTime = hoSoInfo.NgayNop;
                arg_352_0.Add(arg_34D_0 + (dateTime.HasValue ? dateTime.GetValueOrDefault().ToString("dd/MM/yyyy") : null));
            }
            dateTime = hoSoInfo.NgayKiemTraNoiNghiep;
            bool hasValue3 = dateTime.HasValue;
            if (hasValue3)
            {
                List<string> arg_3A2_0 = list3;
                string arg_39D_0 = "Ngày kiểm tra: ";
                dateTime = hoSoInfo.NgayKiemTraNoiNghiep;
                arg_3A2_0.Add(arg_39D_0 + (dateTime.HasValue ? dateTime.GetValueOrDefault().ToString("dd/MM/yyyy") : null));
            }
            TreeNode node = new TreeNode("Thông tin bản vẽ: " + string.Join(", ", list3));
            treeNode.Nodes.Add(node);
            bool flag11 = !string.IsNullOrEmpty(hoSoInfo.NguoiNopHoSo);
            if (flag11)
            {
                List<string> list4 = new List<string>();
                list4.Add((hoSoInfo.GioiTinhNguoiNop ? "Ông " : "Bà ") + hoSoInfo.NguoiNopHoSo);
                bool flag12 = !string.IsNullOrEmpty(hoSoInfo.SoGiayToNguoiNop);
                if (flag12)
                {
                    list4.Add("Số giấy tờ: " + hoSoInfo.SoGiayToNguoiNop);
                }
                TreeNode node2 = new TreeNode("Người nộp hồ sơ: " + string.Join(", ", list4));
                treeNode.Nodes.Add(node2);
            }
            bool flag13 = hoSoInfo.ThongTinChiTiet.ListGiayChungNhan != null && hoSoInfo.ThongTinChiTiet.ListGiayChungNhan.Count > 0;
            if (flag13)
            {
                TreeNode treeNode2 = new TreeNode("Giấy chứng nhận");
                treeNode.Nodes.Add(treeNode2);
                foreach (GiayChungNhan current3 in hoSoInfo.ThongTinChiTiet.ListGiayChungNhan)
                {
                    List<string> list5 = new List<string>();
                    bool flag14 = !string.IsNullOrEmpty(current3.SoSerial);
                    if (flag14)
                    {
                        list5.Add("Số hiệu: " + current3.SoSerial);
                    }
                    bool flag15 = !string.IsNullOrEmpty(current3.SoVaoSo);
                    if (flag15)
                    {
                        list5.Add("Số vào sổ: " + current3.SoVaoSo);
                    }
                    dateTime = current3.NgayVaoSo;
                    bool hasValue4 = dateTime.HasValue;
                    if (hasValue4)
                    {
                        dateTime = current3.NgayVaoSo;
                        string str = dateTime.HasValue ? dateTime.GetValueOrDefault().ToString("dd/MM/yyyy") : null;
                        list5.Add("Ngày VS: " + str);
                    }
                    bool flag16 = !string.IsNullOrEmpty(current3.MaVach);
                    if (flag16)
                    {
                        list5.Add("Mã vạch: " + current3.MaVach);
                    }
                    TreeNode node3 = new TreeNode(string.Join(", ", list5));
                    treeNode2.Nodes.Add(node3);
                }
            }
            bool flag17 = hoSoInfo.ThongTinChiTiet.ListChu != null && hoSoInfo.ThongTinChiTiet.ListChu.Count > 0;
            if (flag17)
            {
                TreeNode treeNode3 = new TreeNode("Chủ sử dụng:");
                treeNode.Nodes.Add(treeNode3);
                foreach (ChuSuDung current4 in hoSoInfo.ThongTinChiTiet.ListChu)
                {
                    List<string> list6 = new List<string>();
                    bool toChuc = current4.ToChuc;
                    if (toChuc)
                    {
                        list6.Add(current4.HoTen);
                    }
                    else
                    {
                        list6.Add((current4.GioiTinh ? "Ông " : "Bà ") + current4.HoTen);
                    }
                    bool flag18 = !string.IsNullOrEmpty(current4.SoGiayTo);
                    if (flag18)
                    {
                        list6.Add("Số giấy tờ: " + current4.SoGiayTo);
                    }
                    bool flag19 = !string.IsNullOrEmpty(current4.DiaChi);
                    if (flag19)
                    {
                        list6.Add("Địa chỉ: " + current4.DiaChi);
                    }
                    TreeNode node4 = new TreeNode(string.Join(", ", list6));
                    treeNode3.Nodes.Add(node4);
                }
            }
            bool flag20 = hoSoInfo.ThongTinChiTiet.ListThua != null && hoSoInfo.ThongTinChiTiet.ListThua.Count > 0;
            if (flag20)
            {
                TreeNode treeNode4 = new TreeNode("Thửa đất:");
                treeNode.Nodes.Add(treeNode4);
                foreach (ThuaDat current5 in hoSoInfo.ThongTinChiTiet.ListThua)
                {
                    List<string> list7 = new List<string>();
                    list7.Add("Số thửa: " + current5.SoThuTuThua);
                    list7.Add("Tờ bản đồ: " + current5.SoHieuToBanDo);
                    bool flag21 = !string.IsNullOrEmpty(current5.DiaChi);
                    if (flag21)
                    {
                        list7.Add("Địa chỉ: " + current5.DiaChi);
                    }
                    TreeNode node5 = new TreeNode(string.Join(", ", list7));
                    treeNode4.Nodes.Add(node5);
                }
            }
            bool flag22 = hoSoInfo.ThongTinChiTiet.ListNha != null && hoSoInfo.ThongTinChiTiet.ListNha.Count > 0;
            if (flag22)
            {
                TreeNode treeNode5 = new TreeNode("Địa chỉ nhà/căn hộ:");
                treeNode.Nodes.Add(treeNode5);
                foreach (Nha current6 in hoSoInfo.ThongTinChiTiet.ListNha)
                {
                    bool laCanHo = current6.LaCanHo;
                    string str2;
                    if (laCanHo)
                    {
                        str2 = "Căn hộ: ";
                    }
                    else
                    {
                        str2 = "Nhà ở: ";
                    }
                    List<string> list8 = new List<string>();
                    bool flag23 = !string.IsNullOrEmpty(current6.SoNha);
                    if (flag23)
                    {
                        list8.Add("Số nhà: " + current6.SoNha);
                    }
                    bool flag24 = !string.IsNullOrEmpty(current6.TenChungCu);
                    if (flag24)
                    {
                        list8.Add("Thuộc chung cư: " + current6.TenChungCu);
                    }
                    bool flag25 = !string.IsNullOrEmpty(current6.DiaChi);
                    if (flag25)
                    {
                        list8.Add("Địa chỉ: " + current6.DiaChi);
                    }
                    TreeNode node6 = new TreeNode(str2 + string.Join(", ", list8));
                    treeNode5.Nodes.Add(node6);
                }
            }
            bool flag26 = hoSoInfo.ThongTinChiTiet.ListFile != null && hoSoInfo.ThongTinChiTiet.ListFile.Count > 0;
            if (flag26)
            {
                TreeNode treeNode6 = new TreeNode("Danh sách file:");
                treeNode.Nodes.Add(treeNode6);
                foreach (FileScan current7 in hoSoInfo.ThongTinChiTiet.ListFile)
                {
                    List<string> list9 = new List<string>();
                    bool flag27 = this._dictLoaiGiayToFileScan.ContainsKey(current7.LoaiGiayToId);
                    if (flag27)
                    {
                        list9.Add(this._dictLoaiGiayToFileScan[current7.LoaiGiayToId] + ": ");
                    }
                    else
                    {
                        list9.Add("Giấy tờ khác: ");
                    }
                    bool flag28 = !string.IsNullOrEmpty(current7.MoTa);
                    if (flag28)
                    {
                        list9.Add(current7.MoTa);
                    }
                    else
                    {
                        list9.Add(current7.FileName);
                    }
                    TreeNode treeNode7 = new TreeNode(string.Join(" ", list9));
                    treeNode7.Tag = "File" + current7.FilePath;
                    treeNode6.Nodes.Add(treeNode7);
                }
            }
            return treeNode;
        }

        private void UpdateData2TreeNode(TreeNode nodeHoSo, ThongTinHoSo hoSoInfo)
        {
            nodeHoSo.Nodes.Clear();
            nodeHoSo.Tag = "ID" + hoSoInfo.ThongTinHoSoId;
            nodeHoSo.NodeFont = this.font;
            string text = "";
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            bool flag = hoSoInfo.ThongTinChiTiet.ListThua != null;
            if (flag)
            {
                foreach (ThuaDat current in hoSoInfo.ThongTinChiTiet.ListThua)
                {
                    bool flag2 = !list.Contains(current.SoThuTuThua);
                    if (flag2)
                    {
                        list.Add(current.SoThuTuThua);
                    }
                    bool flag3 = !list2.Contains(current.SoHieuToBanDo);
                    if (flag3)
                    {
                        list2.Add(current.SoHieuToBanDo);
                    }
                }
                text = " thửa đất số " + string.Join(",", list) + " tờ " + string.Join(",", list2);
            }
            bool flag4 = hoSoInfo.ThongTinChiTiet.ListNha != null;
            if (flag4)
            {
                list = new List<string>();
                foreach (Nha current2 in hoSoInfo.ThongTinChiTiet.ListNha)
                {
                    bool flag5 = current2.LaCanHo && current2.SoNha != "" && !list.Contains(current2.SoNha.ToString());
                    if (flag5)
                    {
                        list.Add(current2.SoNha.ToString());
                    }
                }
                bool flag6 = list.Count > 0;
                if (flag6)
                {
                    bool flag7 = text == "";
                    if (flag7)
                    {
                        text = " căn hộ " + string.Join(",", list);
                    }
                    else
                    {
                        text = text + "; căn hộ " + string.Join(",", list);
                    }
                }
            }
            string text2 = "";
            bool flag8 = !string.IsNullOrEmpty(hoSoInfo.NguoiCapNhat);
            if (flag8)
            {
                text2 += hoSoInfo.NguoiCapNhat;
            }
            DateTime? dateTime = hoSoInfo.NgayChinhSua;
            bool hasValue = dateTime.HasValue;
            if (hasValue)
            {
                string arg_26B_0 = text2;
                string arg_26B_1 = " cập nhật ngày ";
                dateTime = hoSoInfo.NgayChinhSua;
                text2 = arg_26B_0 + arg_26B_1 + (dateTime.HasValue ? dateTime.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss") : null);
            }
            nodeHoSo.Text = string.Concat(new string[]
            {
                "Hồ sơ bản vẽ",
                text,
                "; ",
                GlobalVariable.TenXa,
                "; ",
                text2,
                "                    "
            });
            List<string> list3 = new List<string>();
            bool flag9 = !string.IsNullOrEmpty(hoSoInfo.SoBienNhan);
            if (flag9)
            {
                list3.Add("Số biên nhận: " + hoSoInfo.SoBienNhan);
            }
            bool flag10 = !string.IsNullOrEmpty(hoSoInfo.SoBanVe);
            if (flag10)
            {
                list3.Add("Số bản vẽ: " + hoSoInfo.SoBanVe);
            }
            dateTime = hoSoInfo.NgayNop;
            bool hasValue2 = dateTime.HasValue;
            if (hasValue2)
            {
                List<string> arg_35C_0 = list3;
                string arg_357_0 = "Ngày nộp: ";
                dateTime = hoSoInfo.NgayNop;
                arg_35C_0.Add(arg_357_0 + (dateTime.HasValue ? dateTime.GetValueOrDefault().ToString("dd/MM/yyyy") : null));
            }
            dateTime = hoSoInfo.NgayKiemTraNoiNghiep;
            bool hasValue3 = dateTime.HasValue;
            if (hasValue3)
            {
                List<string> arg_3AC_0 = list3;
                string arg_3A7_0 = "Ngày kiểm tra: ";
                dateTime = hoSoInfo.NgayKiemTraNoiNghiep;
                arg_3AC_0.Add(arg_3A7_0 + (dateTime.HasValue ? dateTime.GetValueOrDefault().ToString("dd/MM/yyyy") : null));
            }
            TreeNode node = new TreeNode("Thông tin bản vẽ: " + string.Join(", ", list3));
            nodeHoSo.Nodes.Add(node);
            bool flag11 = !string.IsNullOrEmpty(hoSoInfo.NguoiNopHoSo);
            if (flag11)
            {
                List<string> list4 = new List<string>();
                list4.Add((hoSoInfo.GioiTinhNguoiNop ? "Ông " : "Bà ") + hoSoInfo.NguoiNopHoSo);
                bool flag12 = !string.IsNullOrEmpty(hoSoInfo.SoGiayToNguoiNop);
                if (flag12)
                {
                    list4.Add("Số giấy tờ: " + hoSoInfo.SoGiayToNguoiNop);
                }
                TreeNode node2 = new TreeNode("Người nộp hồ sơ: " + string.Join(", ", list4));
                nodeHoSo.Nodes.Add(node2);
            }
            bool flag13 = hoSoInfo.ThongTinChiTiet.ListGiayChungNhan != null && hoSoInfo.ThongTinChiTiet.ListGiayChungNhan.Count > 0;
            if (flag13)
            {
                TreeNode treeNode = new TreeNode("Giấy chứng nhận");
                nodeHoSo.Nodes.Add(treeNode);
                foreach (GiayChungNhan current3 in hoSoInfo.ThongTinChiTiet.ListGiayChungNhan)
                {
                    List<string> list5 = new List<string>();
                    bool flag14 = !string.IsNullOrEmpty(current3.SoSerial);
                    if (flag14)
                    {
                        list5.Add("Số hiệu: " + current3.SoSerial);
                    }
                    bool flag15 = !string.IsNullOrEmpty(current3.SoVaoSo);
                    if (flag15)
                    {
                        list5.Add("Số vào sổ: " + current3.SoVaoSo);
                    }
                    dateTime = current3.NgayVaoSo;
                    bool hasValue4 = dateTime.HasValue;
                    if (hasValue4)
                    {
                        dateTime = current3.NgayVaoSo;
                        string str = dateTime.HasValue ? dateTime.GetValueOrDefault().ToString("dd/MM/yyyy") : null;
                        list5.Add("Ngày VS: " + str);
                    }
                    bool flag16 = !string.IsNullOrEmpty(current3.MaVach);
                    if (flag16)
                    {
                        list5.Add("Mã vạch: " + current3.MaVach);
                    }
                    TreeNode node3 = new TreeNode(string.Join(", ", list5));
                    treeNode.Nodes.Add(node3);
                }
            }
            bool flag17 = hoSoInfo.ThongTinChiTiet.ListChu != null && hoSoInfo.ThongTinChiTiet.ListChu.Count > 0;
            if (flag17)
            {
                TreeNode treeNode2 = new TreeNode("Chủ sử dụng:");
                nodeHoSo.Nodes.Add(treeNode2);
                foreach (ChuSuDung current4 in hoSoInfo.ThongTinChiTiet.ListChu)
                {
                    List<string> list6 = new List<string>();
                    bool toChuc = current4.ToChuc;
                    if (toChuc)
                    {
                        list6.Add(current4.HoTen);
                    }
                    else
                    {
                        list6.Add((current4.GioiTinh ? "Ông " : "Bà ") + current4.HoTen);
                    }
                    bool flag18 = !string.IsNullOrEmpty(current4.SoGiayTo);
                    if (flag18)
                    {
                        list6.Add("Số giấy tờ: " + current4.SoGiayTo);
                    }
                    bool flag19 = !string.IsNullOrEmpty(current4.DiaChi);
                    if (flag19)
                    {
                        list6.Add("Địa chỉ: " + current4.DiaChi);
                    }
                    TreeNode node4 = new TreeNode(string.Join(", ", list6));
                    treeNode2.Nodes.Add(node4);
                }
            }
            bool flag20 = hoSoInfo.ThongTinChiTiet.ListThua != null && hoSoInfo.ThongTinChiTiet.ListThua.Count > 0;
            if (flag20)
            {
                TreeNode treeNode3 = new TreeNode("Thửa đất:");
                nodeHoSo.Nodes.Add(treeNode3);
                foreach (ThuaDat current5 in hoSoInfo.ThongTinChiTiet.ListThua)
                {
                    List<string> list7 = new List<string>();
                    list7.Add("Số thửa: " + current5.SoThuTuThua);
                    list7.Add("Tờ bản đồ: " + current5.SoHieuToBanDo);
                    bool flag21 = !string.IsNullOrEmpty(current5.DiaChi);
                    if (flag21)
                    {
                        list7.Add("Địa chỉ: " + current5.DiaChi);
                    }
                    TreeNode node5 = new TreeNode(string.Join(", ", list7));
                    treeNode3.Nodes.Add(node5);
                }
            }
            bool flag22 = hoSoInfo.ThongTinChiTiet.ListNha != null && hoSoInfo.ThongTinChiTiet.ListNha.Count > 0;
            if (flag22)
            {
                TreeNode treeNode4 = new TreeNode("Nhà/căn hộ:");
                nodeHoSo.Nodes.Add(treeNode4);
                foreach (Nha current6 in hoSoInfo.ThongTinChiTiet.ListNha)
                {
                    bool laCanHo = current6.LaCanHo;
                    string str2;
                    if (laCanHo)
                    {
                        str2 = "Căn hộ: ";
                    }
                    else
                    {
                        str2 = "Nhà ở: ";
                    }
                    List<string> list8 = new List<string>();
                    bool flag23 = !string.IsNullOrEmpty(current6.SoNha);
                    if (flag23)
                    {
                        list8.Add("Số nhà: " + current6.SoNha);
                    }
                    bool flag24 = !string.IsNullOrEmpty(current6.TenChungCu);
                    if (flag24)
                    {
                        list8.Add("Thuộc chung cư: " + current6.TenChungCu);
                    }
                    bool flag25 = !string.IsNullOrEmpty(current6.DiaChi);
                    if (flag25)
                    {
                        list8.Add("Địa chỉ: " + current6.DiaChi);
                    }
                    TreeNode node6 = new TreeNode(str2 + string.Join(", ", list8));
                    treeNode4.Nodes.Add(node6);
                }
            }
            bool flag26 = hoSoInfo.ThongTinChiTiet.ListFile != null && hoSoInfo.ThongTinChiTiet.ListFile.Count > 0;
            if (flag26)
            {
                TreeNode treeNode5 = new TreeNode("Danh sách file:");
                nodeHoSo.Nodes.Add(treeNode5);
                foreach (FileScan current7 in hoSoInfo.ThongTinChiTiet.ListFile)
                {
                    List<string> list9 = new List<string>();
                    bool flag27 = this._dictLoaiGiayToFileScan.ContainsKey(current7.LoaiGiayToId);
                    if (flag27)
                    {
                        list9.Add(this._dictLoaiGiayToFileScan[current7.LoaiGiayToId] + ": ");
                    }
                    else
                    {
                        list9.Add("Giấy tờ khác: ");
                    }
                    bool flag28 = !string.IsNullOrEmpty(current7.MoTa);
                    if (flag28)
                    {
                        list9.Add(current7.MoTa);
                    }
                    else
                    {
                        list9.Add(current7.FileName);
                    }
                    TreeNode treeNode6 = new TreeNode(string.Join(" ", list9));
                    treeNode6.Tag = "File" + current7.FilePath;
                    treeNode5.Nodes.Add(treeNode6);
                }
            }
            this.hideTreeNode(nodeHoSo);
            nodeHoSo.ExpandAll();
        }

        private void AddData2FirstTreeView(ThongTinHoSo value)
        {
            this._dictHoSo.Add(value.ThongTinHoSoId, value);
            TreeNode treeNode = this.AddData2TreeNode(value);
            this.trvHoSo.Nodes.Insert(0, treeNode);
            this.hideTreeNode(treeNode);
            treeNode.ExpandAll();
        }

        private void LoadData2TreeView(ThongTinHoSo value)
        {
            this.trvHoSo.Nodes.Clear();
            this._dictHoSo = new Dictionary<long, ThongTinHoSo>();
            this._dictHoSo.Add(value.ThongTinHoSoId, value);
            _rootId = value.RootId;
            long? num = value.KhoaChaId;
            while (num.HasValue)
            {
                ThongTinHoSoEntity thongTinHoSoEntity = ManageBase.SelectThongTinHoSoById(num.Value);
                num = null;
                bool flag = thongTinHoSoEntity != null;
                if (flag)
                {
                    ThongTinHoSo thongTinHoSo = ProcessData.MapThongTinHoSo(thongTinHoSoEntity);
                    num = thongTinHoSo.KhoaChaId;
                    this._dictHoSo.Add(thongTinHoSo.ThongTinHoSoId, thongTinHoSo);
                }
            }
            foreach (KeyValuePair<long, ThongTinHoSo> current in this._dictHoSo)
            {
                TreeNode node = this.AddData2TreeNode(current.Value);
                this.trvHoSo.Nodes.Add(node);
            }
            foreach (TreeNode node2 in this.trvHoSo.Nodes)
            {
                this.hideTreeNode(node2);
            }
            this.trvHoSo.ExpandAll();
        }

        private bool DeleteInfoDocument(long thongTinHoSoId, out string message)
        {
            message = "";
            bool result = true;
            long? num = null;
            try
            {
                while (thongTinHoSoId > 0L)
                {
                    TreeNode node = null;
                    foreach (TreeNode treeNode in this.trvHoSo.Nodes)
                    {
                        long num2 = Convert.ToInt64(treeNode.Tag.ToString().Substring(2));
                        bool flag = thongTinHoSoId == num2;
                        if (flag)
                        {
                            node = treeNode;
                            num = this._dictHoSo[num2].KhoaChaId;
                            break;
                        }
                    }
                    bool flag2 = thongTinHoSoId > 0L;
                    if (flag2)
                    {
                        bool flag3 = ManageBase.DeleteThongTinHoSo(thongTinHoSoId);
                        if (flag3)
                        {
                            this._dictHoSo.Remove(thongTinHoSoId);
                            this.trvHoSo.Nodes.Remove(node);
                            bool hasValue = num.HasValue;
                            if (hasValue)
                            {
                                thongTinHoSoId = num.Value;
                            }
                            else
                            {
                                thongTinHoSoId = 0L;
                            }
                            num = null;
                        }
                        else
                        {
                            result = false;
                            message = "Không có dữ liệu";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                message = ex.Message;
            }
            return result;
        }

        public void ClearData()
        {
            _rootId = 0;
            this._dictHoSo.Clear();
            this.trvHoSo.Nodes.Clear();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            bool flag = this.frmNhapHoSo == null;
            if (flag)
            {
                this.frmNhapHoSo = new FormNhapHoSo();
            }
            long num = 0L;
            bool flag2 = this.chkLayThongTinCu.Checked && this.trvHoSo.Nodes.Count > 0;
            ThongTinHoSo thongTinHoSo;
            if (flag2)
            {
                TreeNode treeNode = this.trvHoSo.Nodes[0];
                num = Convert.ToInt64(treeNode.Tag.ToString().Substring(2));
                thongTinHoSo = JsonConvert.DeserializeObject<ThongTinHoSo>(JsonConvert.SerializeObject(this._dictHoSo[num]));
                thongTinHoSo.SoBienNhan = "";
                thongTinHoSo.NgayHenTra = null;
                thongTinHoSo.NgayTraHoSo = null;
                thongTinHoSo.NgayKiemTraNoiNghiep = null;
                thongTinHoSo.NgayNop = null;
                thongTinHoSo.GhiChu = "";
                thongTinHoSo.LoaiBienDongId = null;
                thongTinHoSo.SoBanVe = "";
                thongTinHoSo.PhiDoVe = null;
                thongTinHoSo.PhiThamDinh = null;
                thongTinHoSo.ChuyenVienId = null;
                thongTinHoSo.ChuyenVienKiemTra = "";
                thongTinHoSo.HoSoKhongHopLy = false;
                thongTinHoSo.HoSoDaKiemTra = false;
                thongTinHoSo.HoSoChuaDat = false;
                thongTinHoSo.CongTyDoVeId = null;
                thongTinHoSo.CongTyDoVe = "";
                thongTinHoSo.NgayChinhSua = null;
                thongTinHoSo.NguoiCapNhat = "";
                thongTinHoSo.LichSuCapNhat = null;
                bool flag3 = thongTinHoSo.ThongTinChiTiet != null;
                if (flag3)
                {
                    thongTinHoSo.ThongTinChiTiet.ListFile = null;
                }
            }
            else
            {
                thongTinHoSo = new ThongTinHoSo();
            }
            if (trvHoSo.Nodes.Count == 0)
            {
                _rootId = ManageBase.GetRootId();
                if (_rootId == 0)
                {
                    MessageBox.Show("Không thể khởi tạo dữ liệu Root!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            thongTinHoSo.RootId = _rootId;
            thongTinHoSo.ThongTinHoSoId = 0L;
            thongTinHoSo.IsNew = true;
            thongTinHoSo.IsSuccess = false;
            thongTinHoSo.LaHoSoMoiNhat = true;
            bool flag4 = num > 0L;
            if (flag4)
            {
                thongTinHoSo.KhoaChaId = new long?(num);
            }
            this.frmNhapHoSo._thongTinHoSo = thongTinHoSo;
            this.frmNhapHoSo.ShowDialog();
            bool isSuccess = this.frmNhapHoSo._thongTinHoSo.IsSuccess;
            if (isSuccess)
            {
                thongTinHoSo = JsonConvert.DeserializeObject<ThongTinHoSo>(JsonConvert.SerializeObject(this.frmNhapHoSo._thongTinHoSo));
                bool flag5 = num > 0L;
                if (flag5)
                {
                    this._dictHoSo[num].LaHoSoMoiNhat = false;
                    this.AddData2FirstTreeView(thongTinHoSo);
                }
                else
                {
                    this.LoadData2TreeView(thongTinHoSo);
                }
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            bool flag = this.frmNhapHoSo == null;
            if (flag)
            {
                this.frmNhapHoSo = new FormNhapHoSo();
            }
            TreeNode treeNode = null;
            long key = 0L;
            foreach (TreeNode treeNode2 in this.trvHoSo.Nodes)
            {
                bool @checked = treeNode2.Checked;
                if (@checked)
                {
                    treeNode = treeNode2;
                    key = Convert.ToInt64(treeNode2.Tag.ToString().Substring(2));
                    this.frmNhapHoSo._thongTinHoSo = JsonConvert.DeserializeObject<ThongTinHoSo>(JsonConvert.SerializeObject(this._dictHoSo[key]));
                    this.frmNhapHoSo._thongTinHoSo.IsNew = false;
                    this.frmNhapHoSo._thongTinHoSo.IsSuccess = false;
                    break;
                }
            }
            bool flag2 = treeNode != null;
            if (flag2)
            {
                this.frmNhapHoSo.ShowDialog();
                bool isSuccess = this.frmNhapHoSo._thongTinHoSo.IsSuccess;
                if (isSuccess)
                {
                    this._dictHoSo[key] = JsonConvert.DeserializeObject<ThongTinHoSo>(JsonConvert.SerializeObject(this.frmNhapHoSo._thongTinHoSo));
                    this.UpdateData2TreeNode(treeNode, this._dictHoSo[key]);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bool flag = this.frmTimKiem == null;
            if (flag)
            {
                this.frmTimKiem = new FormTimKiem();
            }
            this.frmTimKiem.ShowDialog();
            bool flag2 = this.frmTimKiem.ThongTinHS != null;
            if (flag2)
            {
                this.LoadData2TreeView(this.frmTimKiem.ThongTinHS);
            }
        }

        private void FormThongTinHoSo_Load(object sender, EventArgs e)
        {
            this._dictHoSo = new Dictionary<long, ThongTinHoSo>();
            this.trvHoSo.Nodes.Clear();
        }

        private void trvHoSo_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            bool flag = node.Tag.ToString().Contains("ID");
            if (flag)
            {
                bool @checked = node.Checked;
                if (@checked)
                {
                    this.trvHoSo.AfterCheck -= new TreeViewEventHandler(this.trvHoSo_AfterCheck);
                    foreach (TreeNode treeNode in this.trvHoSo.Nodes)
                    {
                        treeNode.Checked = false;
                    }
                    node.Checked = true;
                    this.trvHoSo.AfterCheck += new TreeViewEventHandler(this.trvHoSo_AfterCheck);
                }
            }
        }

        private void btnTuiHSMoi_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void trvHoSo_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.trvHoSo.SelectedNode;
            bool flag = selectedNode.Tag != null && selectedNode.Tag.ToString().Contains("File");
            if (flag)
            {
                this.Cursor = Cursors.WaitCursor;
                string filePathServer = selectedNode.Tag.ToString().Substring(4);
                ProcessData.ReadFileFromServer(filePathServer);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            long num = 0L;
            long? num2 = null;
            foreach (TreeNode treeNode in this.trvHoSo.Nodes)
            {
                bool @checked = treeNode.Checked;
                if (@checked)
                {
                    num = Convert.ToInt64(treeNode.Tag.ToString().Substring(2));
                    num2 = this._dictHoSo[num].KhoaChaId;
                    break;
                }
            }
            bool flag = num > 0L;
            if (flag)
            {
                bool flag2 = MessageBox.Show("Bạn có chắc chắn muốn xoá hồ sơ đã chọn?" + Environment.NewLine + "Các hồ sơ lịch sử của hồ sơ đã chọn sẽ được xoá.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK;
                if (flag2)
                {
                    string str;
                    bool flag3 = !this.DeleteInfoDocument(num, out str);
                    if (flag3)
                    {
                        MessageBox.Show("Lỗi: " + str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
