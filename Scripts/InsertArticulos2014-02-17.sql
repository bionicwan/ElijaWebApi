
  insert into NodeType([Description])
  values ('Menu')

  insert into NodeType([Description])
  values ('Section')

  insert into NodeType([Description])
  values ('Article')

  insert into Node(NodeTypeId, ParentId, [Level], Name, [Text], IsActive, CreatedAt)
  values(1, 0, 1, 'Banquetes', null, 1, GETDATE())

  insert into Node(NodeTypeId, ParentId, [Level], Name, [Text], IsActive, CreatedAt)
  values(1, 0, 1, 'Audio E Iluminación', null, 1, GETDATE())

  insert into Node(NodeTypeId, ParentId, [Level], Name, [Text], IsActive, CreatedAt)
  values(1, 0, 1, 'Banquete A Tu Medida', null, 1, GETDATE())

  insert into Node(NodeTypeId, ParentId, [Level], Name, [Text], IsActive, CreatedAt)
  values(1, 0, 1, '¿Quienes Somos?', null, 1, GETDATE())

  insert into Node(NodeTypeId, ParentId, [Level], Name, [Text], IsActive, CreatedAt)
  values(1, 0, 1, '¿Y Por Qué No?', null, 1, GETDATE())

  insert into ImageType([Description]) values ('Thumbnail')
  insert into ImageType([Description]) values ('Small')
  insert into ImageType([Description]) values ('Medium')
  insert into ImageType([Description]) values ('Large')
  insert into ImageType([Description]) values ('Small_LQ')
  insert into ImageType([Description]) values ('Medium_LQ')
  insert into ImageType([Description]) values ('Large_LQ')

  insert into Image(Url, Width, Height, Size, ImageTypeId, NodeId)
  values('C:\uploads\saint-seiya-sagitario-myth-cloth-ex-ver-jp-nuevo-y-sellado_MLC-F-3129159940_092012_thumb.jpg', 400, 300, 27200, 1, 1)

  insert into Image(Url, Width, Height, Size, ImageTypeId, NodeId)
  values('C:\uploads\saint-seiya-sagitario-myth-cloth-ex-ver-jp-nuevo-y-sellado_MLC-F-3129159940_092012_small.jpg', 600, 450, 50100, 2, 1)

  insert into Image(Url, Width, Height, Size, ImageTypeId, NodeId)
  values('C:\uploads\saint-seiya-sagitario-myth-cloth-ex-ver-jp-nuevo-y-sellado_MLC-F-3129159940_092012_medium.jpg', 900, 675, 92500, 3, 1)

  insert into Image(Url, Width, Height, Size, ImageTypeId, NodeId)
  values('C:\uploads\saint-seiya-sagitario-myth-cloth-ex-ver-jp-nuevo-y-sellado_MLC-F-3129159940_092012_large.jpg', 1200, 900, 142000, 4, 1)

  insert into Image(Url, Width, Height, Size, ImageTypeId, NodeId)
  values('C:\uploads\saint-seiya-sagitario-myth-cloth-ex-ver-jp-nuevo-y-sellado_MLC-F-3129159940_092012_small_lq.jpg', 600, 450, 22500, 5, 1)

  insert into Image(Url, Width, Height, Size, ImageTypeId, NodeId)
  values('C:\uploads\saint-seiya-sagitario-myth-cloth-ex-ver-jp-nuevo-y-sellado_MLC-F-3129159940_092012_medium_lq.jpg', 900, 675, 41200, 6, 1)

  insert into Image(Url, Width, Height, Size, ImageTypeId, NodeId)
  values('C:\uploads\saint-seiya-sagitario-myth-cloth-ex-ver-jp-nuevo-y-sellado_MLC-F-3129159940_092012_large_lq.jpg', 1200, 900, 62900, 7, 1)
